## Todo App API

This is the API for Todo App.

**BASE URL**: https://todointern.azurewebsites.net/


### 1. api/Todo (GET)

Get the list of todo items.

#### Example Response
```json
[
    {

        "TodoId": 12,
        "Task": "Hello",
        "Description": "Desc",
        "Date": "2017-12-23T13:07:31.85",
        "Done": false

    }
]
```

### 2. api/Todo (POST)

This endpoint can be used to add a Todo.x

#### Body
```json
{
    "Task":"qwerty",
    "Description":"ghdg",
    "Done" : false
}
```
### 3. api/Todo/{id} (PUT)

This endpoint can be used to update a Todo item,where 'id' denotes the unique value for each item.

#### Body
```json
{
    "Task":"twing",
    "Description":"adf",
    "Done" : false
}
```
### 4. api/Todo/{id} (DELETE)
This endpoint can be used to delete a Todo item,where 'id' denotes unique value for each item.

### 5.api/Todo/done/{id} (GET)
This endpoint is used to indicate whether the bit is set or not.