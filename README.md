[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/BDnnw_r8)
# Instructions for Creating a Pet Name Generator REST API

## 1. Set Up the Project
- Create a new project for the REST API.

## 2. Create an Endpoint
- The API should listen for **POST requests** at `/generate`.

## 3. Accept User Input
- The request body must include:
  - `animalType` (required) – Must be **dog, cat, or bird**.
  - `twoPart` (optional) – If `true`, the generated name will have two parts.

## 4. Validate User Input
- **Check if `animalType` is missing**:
  - If not provided, return a **400 Bad Request** response with an error message.
- **Check if `animalType` is valid**:
  - If it is not **dog, cat, or bird**, return a **400 Bad Request** response with an error message.
- **Validate `twoPart` (if provided)**:
  - If included, it must be a boolean (`true` or `false`).
  - If not a boolean, return a **400 Bad Request** response with an error message.

## 5. Prepare Name Lists
- Define name options for each animal type:
  - **Dog**: Buddy, Max, Charlie, Rocky, Rex
  - **Cat**: Whiskers, Mittens, Luna, Simba, Tiger
  - **Bird**: Tweety, Sky, Chirpy, Raven, Sunny

## 6. Generate a Pet Name
- If `twoPart` is **false** or missing, return **one** random name.
- If `twoPart` is **true**, combine **two random names** into one.

## 7. Return the Response
- Send the generated pet name in **JSON format**.

## 8. Test the API
- Run the API and send a **POST request** with `animalType` to verify functionality.
- Test invalid inputs to ensure proper validation and error handling.

**  Sample:**  

**Description:**  
Generates a pet name based on the provided animal type.

**Request Body:**
```json
{
  "animalType": "dog",
  "twoPart": true
}
```
**Responses:**
Success Response (200 OK)
```json
{
  "name": "RockyRex"
}
```

Error Responses
Invalid Animal Type (400 Bad Request)

```json
{
  "error": "Invalid animal type. Allowed values: dog, cat, bird."
}
```

Missing Animal Type (400 Bad Request)
```json
{
  "error": "The 'animalType' field is required."
}
```

Invalid twoPart Value (400 Bad Request)

```json
{
  "error": "The 'twoPart' field must be a boolean (true or false)."
}
```
