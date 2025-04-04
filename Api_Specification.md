# API Specification Kayak Cove

## Products API
version: 1.0.0

API for managing product data.


### GET: Retrieve all products.
```YAML
/api/Products
```
```YAML
responses:
    '200':
        description: List of all products.
```

### GET: Fetch a specific product by ID.
```YAML
/api/Products/{id}
```
```YAML
parameters:
    name: id
        required: true
        schema:
            type: int
```
```YAML
responses:
    '200':
        description: The requested product.
```

### POST: Create a new product.
```YAML
/api/Products
```
```YAML
requestBody:
    required: true
    content:
        application/json:
        schema:
            type: object
            properties:
            name:
                type: string
            price:
                type: decimal
            category:
                type: string
```
 
```YAML
responses:
'201':
    description: Product created successfully.
```
### PUT: Update a product by ID.
```YAML
/api/Products/{id}
```
```YAML
parameters:
    name: id
        required: true
        schema:
            type: int
```
```YAML
requestBody:
required: true
content:
    application/json:
    schema:
        type: object
        properties:
        name:
            type: string
        price:
            type: decimal
        category:
            type: string
    example:
        name: "Updated Product Name"
        price: 24.99
        category: "Updated Category"
```
```YAML
responses:
'200':
    description: Product updated successfully.
```
### Delete: Delete a product by ID.
```YAML
parameters:
    name: id
        required: true
    schema:
        type: int
```
```YAML
responses:
    '204':
        description: Product deleted successfully.
```
