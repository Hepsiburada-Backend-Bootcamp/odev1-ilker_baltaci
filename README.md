# odev1-ilker_baltaci
## Homework - 1 (API project)

- In this project, it was trying to work according to the Rest standard.

- FluentValidation.AspNetCore framework was used for applying validation processes to the model.

- Tested API's with Postman and you can check the results below.

Get request from "../api/employee" for getting all data

<img src="images/apiproject_1.png"></img>

Get request from "../api/employee/{id}" for getting employee element by id

<img src="images/apiproject_2.png"></img>

Get request from "../api/employee/list?name=ilker&profession=engineer" for listing elements by adding query elements 

<img src="images/apiproject_3.png"></img>

Get request from "../api/employee/sort?name=true" by sorting with id, name, profession, age parameters

<img src="images/apiproject_4.png"></img>

Post request from "../api/employee" with model binding by applying [FromBody] and considering validations 

<img src="images/apiproject_5.png"></img>

Validation errors notation

<img src="images/apiproject_6.png"></img>

Put request from "../api/employee" with model binding by applying [FromBody] and considering validations 

<img src="images/apiproject_7.png"></img>

Deleting request from "../api/employee" 

<img src="images/apiproject_8.png"></img>

