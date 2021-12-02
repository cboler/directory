'use strict'

var express = require('express')
var elasticsearch = require('elasticsearch')
const fs = require('fs')
const path = require('path')
const app = express()
const port = 3000

var client = elasticsearch.Client({
    host: 'http://localhost:9200'
})

async function setup() {
    let rawdata = fs.readFileSync(path.resolve(__dirname, 'data.json'))
    let data = JSON.parse(rawdata)
    const body = data.flatMap(doc => [{ index: { _index: 'phonedirectory' } }, doc])

    // i could just empty it each time... this is ugly. 
    // todo: clean it up
    client.exists({
        index: 'phonedirectory',
        id: 1
    }).then(existsResult => {
        if(!existsResult){
            client.indices.create({
                index: 'phonedirectory',
                body: {
                    mappings: {
                        properties: {
                            id: { type: 'integer' },
                            name: { type: 'text' },
                            address: { type: 'text' },
                            phone: { type: 'text' }
                        }
                    }
                }
            }, { ignore: [400] }).then(result => {
                console.log(result)

                client.bulk({ refresh: true, body }).then(bulkResponse => {
                    if (bulkResponse.errors) {
                        const erroredDocuments = []
                        bulkResponse.items.forEach((action, i) => {
                            const operation = Object.keys(action)[0]
                            if (action[operation].error) {
                                erroredDocuments.push({
                                    status: action[operation].status,
                                    error: action[operation].error,
                                    operation: body[i * 2],
                                    document: body[i * 2 + 1]
                                })
                            }
                        })
                        console.log(erroredDocuments)
                    }
                }, error => {
                    console.log(error);
                })
            }, error => {
                console.log(error)
            })
        }
    })

    client.count({ index: 'phonedirectory' }).then(body => {
        console.log(body)
    }, error => {
        console.log(error)
    })
}

app.get('/setup', (req, res) => {
    setup().catch(console.log)
    res.send('setup complete')
})

app.get('/name/:name', (req, res) => {
    console.log(req.params.name)
    client.search({
        index: 'phonedirectory',
        body: {
            query: {
                match: {
                    name: req.params.name
                }
            }
        }
    }).then(result => {
        console.log(result)
        res.send(result.hits.hits)
    }, error => {
        console.log(error)
        res.send(error)
    })
})

app.use(function (req, res) {
    res.status(404);
})

app.listen(port, () => {
    console.log(`app listening on ${port}`)
})

