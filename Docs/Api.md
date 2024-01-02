# TaskTracker API

- [TaskTracker API](#tasktracker-api)
  - [Create Task](#create-task)
    - [Create Task](#create-task-1)
    - [Create Task Response](#create-task-response)
  - [Get task](#get-task)
    - [Get Task Request](#get-task-request)
    - [Get Task Response](#get-task-response)
  - [Update Tasl](#update-tasl)
    - [Update Task Request](#update-task-request)
    - [Update Task Response](#update-task-response)
    - [or](#or)
  - [Delete Task](#delete-task)
    - [Delete Task Request](#delete-task-request)
    - [Delete Task Response](#delete-task-response)
    - [or](#or-1)

## Create Task

### Create Task

```js
POST /tasks
```

```json
{
    "description": "Buy scissors"
}
```

### Create Task Response

```js
201 Created
```

```yml
Location: {{host}}/tasks/{{id}}
```

```json
{
  "id": 1,
  "description": "Buy scissors",
  "isComplete": false
}
```

## Get task

### Get Task Request

```js
GET /tasks/{{id}}
```

### Get Task Response

```js
200 Ok
```

```json
{
  "id": 1,
  "description": "Buy scissors",
  "isComplete": false
}
```

## Update Tasl

### Update Task Request

```js
PUT /tasks/{{id}}
```

```json
{
  "id": 1,
  "description": "Buy a pillow",
  "isComplete": false
}
```

### Update Task Response

```js
204 No Content
```

### or

```js
201 Created
```

```yml
Location: {{host}}/tasks/{{id}}
```

## Delete Task

### Delete Task Request

```js
DELETE /task/{{id}}
```

### Delete Task Response

```js
200 OK
```
### or

```js
204 No Content
```