# -:: API Specification for Kayak Cove ::-

## Available APIs
- [Product](#Products-API)
- [Category](#Category-API)
- [Role](#Role-API)
- [User](#User-API)
- [Order](#Order-API)
- [Order Details](#Order-Details-API)
- [Authenticate](#Authenticate-API)


##
# Products API
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
                Name:
                    type: string
                Description:
                    type: string
                ImageUri:
                    type: string
                Price:
                    type: decimal
                HasExpired:
                    type: bool
                CategoryId:
                    type: int
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
            Name:
                type: string
            Description:
                type: string
            ImageUri:
                type: string
            Price:
                type: decimal
            HasExpired:
                type: bool
            CategoryId:
                type: int
```
```YAML
responses:
'200':
    description: Product updated successfully.
```
### Delete: Delete a product by ID.
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
    '204':
        description: Product deleted successfully.
```
##
# Category API
version: 1.0.0

API for managing category data.

### GET: Retrieve all categories.
```YAML
/api/Category
```
```YAML
responses:
    '200':
        description: List of all categories.
```

### GET: Fetch a specific category by ID.
```YAML
/api/Category/{id}
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
        description: The requested category.
```

### POST: Create a new category.
```YAML
/api/Category
```
```YAML
requestBody:
    required: true
    content:
        application/json:
        schema:
            type: object
            properties:
                Name:
                    type: string
```
 
```YAML
responses:
'201':
    description: Category created successfully.
```
### PUT: Update a category by ID.
```YAML
/api/Category/{id}
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
            Name:
                type: string
```
```YAML
responses:
'200':
    description: Category updated successfully.
```
### Delete: Delete a category by ID.
```YAML
/api/Category/{id}
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
    '204':
        description: Category deleted successfully.
```
##
# Role API
version: 1.0.0

API for managing user role data.

### GET: Retrieve all roles.
```YAML
/api/Role
```
```YAML
responses:
    '200':
        description: List of all roles.
```

### GET: Fetch a specific role by ID.
```YAML
/api/Role/{id}
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
        description: The requested role.
```
##
# User API
version: 1.0.0

API for managing user data.

### GET: Retrieve all users.
```YAML
/api/User
```
```YAML
responses:
    '200':
        description: List of all users.
```

### GET: Fetch a specific category by ID.
```YAML
/api/User/{id}
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
        description: The requested user.
```

### POST: Create a new user.
```YAML
/api/User
```
```YAML
requestBody:
    required: true
    content:
        application/json:
        schema:
            type: object
            properties:
                Username:
                    type: string
                Firstname:
                    type: string
                Lastname:
                    type: string
                Email:
                    type: string
                Phonenumber:
                    type: string
                Strreaddress:
                    type: string
                Postalcode:
                    type: string
                City:
                    type: string
                Country:
                    type: string
                RoleId:
                    type: int
```
 
```YAML
responses:
'201':
    description: User created successfully.
```
### PUT: Update a user by ID.
```YAML
/api/User/{id}
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
            Username:
                type: string
            Firstname:
                type: string
            Lastname:
                type: string
            Email:
                type: string
            Phonenumber:
                type: string
            Strreaddress:
                type: string
            Postalcode:
                type: string
            City:
                type: string
            Country:
                type: string
            RoleId:
                type: int
```
```YAML
responses:
'200':
    description: User updated successfully.
```
### Delete: Delete a user by ID.
```YAML
/api/User/{id}
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
    '204':
        description: User deleted successfully.
```
##
# Order API
version: 1.0.0

API for managing order data.

### GET: Retrieve all orders.
```YAML
/api/Order
```
```YAML
responses:
    '200':
        description: List of all orders.
```

### GET: Fetch a specific order by ID.
```YAML
/api/Order/{id}
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
        description: The requested order.
```

### POST: Create a new order.
```YAML
/api/Order
```
```YAML
requestBody:
    required: true
    content:
        application/json:
        schema:
            type: object
            properties:
                UserId:
                    type: int
                OrderDate:
                    type: DateTime
                OrderStatus:
                    type: string
                GrandTotal:
                    type: decimal
```
 
```YAML
responses:
'201':
    description: Order created successfully.
```
### PUT: Update a order by ID.
```YAML
/api/Order/{id}
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
            UserId:
                type: int
            OrderDate:
                type: DateTime
            OrderStatus:
                type: string
            GrandTotal:
                type: decimal
```
```YAML
responses:
'200':
    description: Order updated successfully.
```
### Delete: Delete a order by ID.
```YAML
/api/Order/{id}
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
    '204':
        description: Order deleted successfully.
```
##
# Order Details API
version: 1.0.0

API for managing order detail data.

### GET: Retrieve all orderdetails.
```YAML
/api/OrderDetails
```
```YAML
responses:
    '200':
        description: List of all order details.
```

### GET: Fetch a specific order by ID.
```YAML
/api/OrderDetails/{id}
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
        description: The requested order details.
```

### POST: Create new order details.
```YAML
/api/OrderDetails
```
```YAML
requestBody:
    required: true
    content:
        application/json:
        schema:
            type: object
            properties:
                OrderId:
                    type: int
                ProductId:
                    type: int
                Quantity:
                    type: int
                UnitPrice:
                    type: decimal
```
 
```YAML
responses:
'201':
    description: Order details created successfully.
```
### PUT: Update a order by ID.
```YAML
/api/OrderDetails/{id}
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
            OrderId:
                type: int
            ProductId:
                type: int
            Quantity:
                type: int
            UnitPrice:
                type: decimal
```
```YAML
responses:
'200':
    description: Order details updated successfully.
```
### Delete: Delete a order by ID.
```YAML
/api/OrderDetails/{id}
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
    '204':
        description: Order details deleted successfully.
```
##
# Authenticate API
version: 1.0.0

API for authenticating user.

### POST: Authenticate user and receive a token.
```YAML
/api/Authenticate/login
```
```YAML
requestBody:
    required: true
    content:
        application/json:
        schema:
            type: object
            properties:
                username:
                    type: string
                password:
                    type: string
```
```YAML
responses:
    '200':
        description: List of all roles.
```
