# SQL - Structured Query Language

## **Database Servers and Database Management Systems (DBMS)**

A **Database Server** is a dedicated computer system that provides database services to other computers (clients) over a network. It manages data storage, retrieval and manipulation. A **Database Management System (DBMS)** is the software running on the database server that interacts with the database to perform these operations.

* Popular examples of DBMS include:
  * SQL Server
  * Postgre
  * Oracle Database
  * MySQL

---

### **Key Concepts of Database Servers**

1. **Centralized Data Storage:**  
   Database servers act as central hubs for storing structured or unstructured data, ensuring all users or applications interact with the same source of truth.
2. **Concurrency and Transactions:**  
   They support multiple users accessing the same data simultaneously while maintaining consistency through mechanisms like transactions, locking, and isolation levels.
3. **Scalability:**  
   Database servers handle growing data and user demand efficiently, offering horizontal (adding more servers) or vertical (increasing hardware resources) scalability.
4. **Security:**  
   A DBMS ensures data integrity, prevents unauthorized access, and provides role-based access controls.
5. **Backup and Recovery:**  
   Database servers often include automated tools to back up data regularly and recover it in case of failures.

---

### **Importance of Database Servers in Software**

1. **Data-Driven Applications:**  
   Modern software, like web or mobile applications, depends heavily on managing and processing large amounts of data efficiently. Database servers power these functionalities.
2. **Improved Performance:**  
   By optimizing data queries, indexing, and caching, database servers enhance application performance significantly.
3. **Integration with Software Systems:**  
   Many frameworks and libraries (like .NET, Django, or Spring Boot) provide seamless integration with databases, enabling developers to build data-centric applications rapidly.
4. **Scalability in Modern Architectures:**  
   In systems like microservices, a database server can scale to support individual services or applications, ensuring uninterrupted operations as demand grows.
5. **Business Intelligence:**  
   Databases store and organize business-critical data, enabling analysis through tools like SQL queries, reports, and dashboards for decision-making.

---

### **How They Work Together in Software**

When building software, developers use **SQL (Structured Query Language)** to interact with the database server via the DBMS. For example, when a customer places an order in an e-commerce application, the software sends SQL commands to store the order details in a database, ensuring the data is available for future processing, like generating invoices or tracking orders.

Usually, a System/Application is devided in 3 tiers:

* Front-end (User Interface): The tier that interacts with the user
* Back-End (Middleware): The tier that executes the main logic of the System
* Database (Persistence): The tier that manages the data
  * Store
  * Protect
  * Manager
  * Retrieve
  * Create
  * Delete
  * etc

![Application Architecture](images/ApplicationArchitecture.png)

## Introduction to SQL

SQL stands for Structured Query Language. It is a language to interact with a Database Server.
A database server is a software to store and manage data.

## Some Context

SQL is usually related to Relational Databases. There are many different types of databases and in general, the database types that are NOT relational are called NO SQL DATABASE.
A quick search and you will find a long list of SQL and NoSQL databases servers. Each database technology is specialized in something. So there is no such thing as the best database technology for all situations.

## SQL Servers

There are several free SQL Server that you can use to practice and each one has different options for clients or IDE:

* Microsoft SQL Server
  * <https://www.microsoft.com/en-us/sql-server/sql-server-downloads>
    * There are two free version: Developer and Express
  * Client: SQL Server Managment Studio (SSMS)
    * <https://learn.microsoft.com/en-us/ssms/sql-server-management-studio-ssms>
* Postgre SQL
  * <https://www.postgresql.org>
  * Client: PGAdmin
    * <https://www.pgadmin.org/>
* SQL Lite
  * <https://www.sqlite.org>
* MYSQL
  * <https://www.mysql.com>

> **ATTENTION**:

* Each SQL Server has some variation of the SQL syntax.
* This material will use SQL Syntax for Microsoft SQL Server.
* This material focuses only on the basic concepts and tries to give a good intro to SQL.

> **RECOMMENDATION**: I recommend an online SQL IDE called SQL Fiddler.
You just need a browser and don't need to install anything.
It supports the SQL Syntax for each one of the listed SQL Servers

* SQL Fiddle: <http://sqlfiddle.com/>

## Database Organization

* A relational database organizes the information in tables and fields.
* A table is an entity to store data.
  * Examples:
    * Customer
    * Product
    * Employee
    * Order
    * Project

* A field is a unit of data that compose a Table.
  * Examples:
    * ID
    * first_name
    * last_name
    * email
    * salary

* A record is a row (instance) of data in a table:
  * Example of of Rows:

| ID | first_name | last_name  | email                    | salary  |
|----|------------|------------|--------------------------|---------|
| 1  | John       | Doe        | <john.doe@example.com>   | $50,000 |
| 2  | Jane       | Smith      | <jane.smith@example.com> | $55,000 |
| 3  | Alice      | Johnson    | <alice.j@example.com>    | $60,000 |
| 4  | Bob        | Williams   | <bob.will@example.com>   | $45,000 |
| 5  | Charlie    | Brown      | <charlie.b@example.com>  | $48,000 |

## Operations

SQL defines a sitaxe to execute commands to:

* Create, update and delete tables
* Insert, Update, Delete and Select rows

## Data Modeling

Data Modeling is the process of creating an abstract representation of the information required for a system.
Data models are built around business needs and contain the data entities (Tables and Field) and their relationships.
The first step to build the Data Layer is the Data Model.

![Data Model example](images/DataModel.png)

> ⚠️ **Warning**: SQL Server commands are not case sensitive. This material will use Upper case just to help with visualization

## CREATE TABLE

A table is defined by a list of fields and before we create a table it is important to understand the field types (DataType).

## Fields Data Types

Full list: <https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16>

* [Numerics](https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16#exact-numerics):
  * [tinyint](https://learn.microsoft.com/en-us/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver16)
  * [smallint](https://learn.microsoft.com/en-us/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver16)
  * [int](https://learn.microsoft.com/en-us/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver16)
  * [bigint](https://learn.microsoft.com/en-us/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver16)
  * [bit](https://learn.microsoft.com/en-us/sql/t-sql/data-types/bit-transact-sql?view=sql-server-ver16)
  * [decimal](https://learn.microsoft.com/en-us/sql/t-sql/data-types/decimal-and-numeric-transact-sql?view=sql-server-ver16)
  * [numeric](https://learn.microsoft.com/en-us/sql/t-sql/data-types/decimal-and-numeric-transact-sql?view=sql-server-ver16)
  * [money](https://learn.microsoft.com/en-us/sql/t-sql/data-types/money-and-smallmoney-transact-sql?view=sql-server-ver16)
  * [smallmoney](https://learn.microsoft.com/en-us/sql/t-sql/data-types/money-and-smallmoney-transact-sql?view=sql-server-ver16)
  * [float](https://learn.microsoft.com/en-us/sql/t-sql/data-types/float-and-real-transact-sql?view=sql-server-ver16)
  * [real](https://learn.microsoft.com/en-us/sql/t-sql/data-types/float-and-real-transact-sql?view=sql-server-ver16)
* [Date and Time](https://dev.mysql.com/doc/refman/8.0/en/date-and-time-types.html)
  * [date](https://learn.microsoft.com/en-us/sql/t-sql/data-types/date-transact-sql?view=sql-server-ver16)
  * [time](https://learn.microsoft.com/en-us/sql/t-sql/data-types/time-transact-sql?view=sql-server-ver16)
  * [datetime](https://learn.microsoft.com/en-us/sql/t-sql/data-types/datetime-transact-sql?view=sql-server-ver16)
  * [datetime2](https://learn.microsoft.com/en-us/sql/t-sql/data-types/datetime2-transact-sql?view=sql-server-ver16)
  * [smalldatetime](https://learn.microsoft.com/en-us/sql/t-sql/data-types/smalldatetime-transact-sql?view=sql-server-ver16)
  * [datetimeoffset](https://learn.microsoft.com/en-us/sql/t-sql/data-types/datetimeoffset-transact-sql?view=sql-server-ver16)
* String (<https://dev.mysql.com/doc/refman/8.0/en/string-types.html>)
  * [char](https://learn.microsoft.com/en-us/sql/t-sql/data-types/char-and-varchar-transact-sql?view=sql-server-ver16)
  * [varchar](https://learn.microsoft.com/en-us/sql/t-sql/data-types/char-and-varchar-transact-sql?view=sql-server-ver16)
  * [text](https://learn.microsoft.com/en-us/sql/t-sql/data-types/ntext-text-and-image-transact-sql?view=sql-server-ver16)
  * [nchar](https://learn.microsoft.com/en-us/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql?view=sql-server-ver16)
  * [nvarchar](https://learn.microsoft.com/en-us/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql?view=sql-server-ver16)
  * [ntext](https://learn.microsoft.com/en-us/sql/t-sql/data-types/ntext-text-and-image-transact-sql?view=sql-server-ver16)
* Others
  * [Unique Identifier (GUID)](https://learn.microsoft.com/en-us/sql/t-sql/data-types/uniqueidentifier-transact-sql?view=sql-server-ver16)
  * [JSON](https://learn.microsoft.com/en-us/sql/t-sql/data-types/json-data-type?view=sql-server-ver16)
  * [XML](https://learn.microsoft.com/en-us/sql/t-sql/xml/xml-transact-sql?view=sql-server-ver16)
  * [Vector](https://learn.microsoft.com/en-us/sql/t-sql/data-types/vector-data-type?view=sql-server-ver16)

### Primary Key

A primary key is a field that uniquely identifies each record in a table.
Primary keys must contain UNIQUE values, and cannot contain NULL values.
A table can have only ONE primary key; and in the table, this primary key can consist of single or multiple columns (fields).
> **ATTENTION**: Most of the time the Primary Key field is called ID and its value is auto generated

* Example of Primary Keys:
  * ID
  * Email
  * SSN
  * EmployeeId
  * StudentId
  * DepartmentId

### Foreign Key

A foreign key is a field designated to store values from a field (usually a Primary Key) from another table.
The foreign key is the mechanism used in relational databases to define relationships between records.

#### Example of Foreign Key

Department Table

| Department ID | Department Name |
| --- | --- |
| 1 | Human Resources |
| 2 | Information Technology |
| 3 | Sales |
| 4 | Finances |

Employee Table

| Employee ID | Department ID | Name | Email |
| --- | --- | --- | --- |
| 1 | 2 | Jose Santos | <jose.santos@noemail.com> |
| 2 | 1 | Leila Rodrigues | <leila.rodrigues@nomail.com> |
| 3 | 2 | Artur Rodrigues | <artur.rodrigues@nomail.com> |
| ... |

> **ATTENTION**: Department ID is a primary key on the Department table and a foreign key on the Employee table.

* The department of an Employee is defined by the value stored at his "Department ID" field.
* Jose Santos and Artur Rodrigues are assigned to the Information Technology Department (Department ID = 2)
* Leila Rodrigues is assigned to the Human Resource Department (Department ID = 1)

### CREATE TABLE sintaxe

```sql
CREATE TABLE table_name (
    column1 datatype,
    column2 datatype,
    column3 datatype,
   ....
);
```

### CREATE TABLE example

```sql
CREATE TABLE Department (
    ID INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(100),
    Abbreviation NVARCHAR(5),
    PRIMARY KEY (ID)
);

CREATE TABLE Employee (
    ID INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(200),
    Email NVARCHAR(200),
    Salary DECIMAL(13,2),
    DepartmentID INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(ID)
);
```

> **WARNING**: When executing multiple SQL statements, it is necessary to finish each one ';'.

## INSERT command

The insert command is used to add records to a table

### Insert Sintaxe

```sql
INSERT INTO table_name (column1, column2, column3, ...)
  VALUES (value1, value2, value3, ...);
```

```sql
INSERT INTO Department (Name, Abbreviation) VALUES ('Human Resources', 'HR');
INSERT INTO Department (Name, Abbreviation) VALUES ('Information Technology', 'IT');
INSERT INTO Department (Name, Abbreviation) VALUES ('Sales', 'SAL');
INSERT INTO Department (Name, Abbreviation) VALUES ('Finances', 'FIN');
INSERT INTO Department (Name, Abbreviation) VALUES ('Marketing', 'MARK');
INSERT INTO Department (Name, Abbreviation) VALUES ('Public Relations', 'PL');
```

> **ATTENTION**: No need to insert the ID field because it is auto-gerenated (AUTO_INCREMENT)

```sql
INSERT INTO Employee (Name, Email, Salary, DepartmentID) VALUES
('Jose Santos', 'jose.santos@noemail.com', 15000.15, 2),
('Leila Rodrigues', 'leila.rodrigues@noemail.com', 200000.20, 1),
('Artur Rodrigues', 'artur.rodrigues@noemail.com', 100000.45, 2),
('Bob Marley', 'bob@noemail.com', 900000.37, 5),
('Mickael Jackson', 'theking@noemail.com', 2000000.00, 5),
('Frank Sinatra', 'sinatra@noemail.com', 700000.67, 5),
('Elon Musk', 'musk@noemail.com', 450000.15, 3),
('Steve Jobs', 'jobs@noemail.com', 1000000.67, 3),
('Lady Gaga', 'ladygaga@noemail.com', 650000.90, 5),
('Britney Spears', 'bspears@noemail.com', 75000.56, 5),
('Oprah Winfrey', 'oprah@noemail.com', 5000000.01,5);
```

> **TIP**: It is possible to insert multiple rows with just one INSERT command. Check the INSERT command on Employee table

## UPDATE command

The UPDATE command is used to modify existing record(s) in a table.

### Update Sintaxe

```sql
UPDATE table_name
  SET column1 = value1, column2 = value2, ...
  [WHERE condition]
```

>⚠️**DANGER**⚠️: If you forget to use the ```WHERE``` clause all the records will be updated.

```sql
UPDATE Department
  SET Abbreviation = 'SA'
  WHERE ID = 3
```

* Update the Department table, setting the Abbreviation to 'SA' for the record with ID equals 3

## DELETE command

The DELETE statement is used to delete records from a table.

### Delete Sitaxe

```sql
DELETE FROM table_name 
  WHERE condition
```

>⚠️**DANGER**⚠️: If you forget to use the ```WHERE``` clause all the records will be deleted.

```sql
DELETE
  FROM Department 
  WHERE ID = 4
```

* The row with ID equals 4 will be deleted from the Department table

## Preparation for the SELECT command examples

* These are the SQL commands to prepare the database for the select examples
* Execute the commands below into your sandbox database to create the tables and insert records necessary for the following examples

```sql
CREATE TABLE Department (
    ID INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(100),
    Abbreviation NVARCHAR(5),
    PRIMARY KEY (ID)
);

CREATE TABLE Employee (
    ID INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(200),
    Email NVARCHAR(200),
    Salary DECIMAL(13,2),
    DepartmentID INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(ID)
);

INSERT INTO Department (Name, Abbreviation) VALUES ('Human Resources', 'HR');
INSERT INTO Department (Name, Abbreviation) VALUES ('Information Technology', 'IT');
INSERT INTO Department (Name, Abbreviation) VALUES ('Sales', 'SAL');
INSERT INTO Department (Name, Abbreviation) VALUES ('Finances', 'FIN');
INSERT INTO Department (Name, Abbreviation) VALUES ('Marketing', 'MARK');
INSERT INTO Department (Name, Abbreviation) VALUES ('Public Relations', 'PL');

INSERT INTO Employee (Name, Email, Salary, DepartmentID) VALUES
('Jose Santos', 'jose.santos@noemail.com', 15000.15, 2),
('Leila Rodrigues', 'leila.rodrigues@noemail.com', 200000.20, 1),
('Artur Rodrigues', 'artur.rodrigues@noemail.com', 100000.45, 2),
('Bob Marley', 'bob@noemail.com', 900000.37, 5),
('Mickael Jackson', 'theking@noemail.com', 2000000.00, 5),
('Frank Sinatra', 'sinatra@noemail.com', 700000.67, 5),
('Elon Musk', 'musk@noemail.com', 450000.15, 3),
('Steve Jobs', 'jobs@noemail.com', 1000000.67, 3),
('Lady Gaga', 'ladygaga@noemail.com', 650000.90, 5),
('Britney Spears', 'bspears@noemail.com', 75000.56, 5),
('Oprah Winfrey', 'oprah@noemail.com', 5000000.01,5);
```

## SELECT command

The SELECT command is used to select/retrieve data.

### Select Sintaxe

```sql
SELECT * 
  FROM table_name;

SELECT column1, column2, ...
  FROM table_name;
  WHERE condition
```

> **TIP**: Using ```SELECT *``` is not recommended as we rarely need all fields. It is better to use a list with only the necessary fields.

## Select all columns and all rows from Employee table

```sql
SELECT *
  FROM Employee
```

| ID |            Name |                         Email |   Salary   | DepartmentID |
|----|-----------------|-------------------------------|------------|--------------|
|  1 |     Jose Santos |     <jose.santos@noemail.com> |   15000.15 |            2 |
|  2 | Leila Rodrigues | <leila.rodrigues@noemail.com> |   200000.2 |            1 |
|  3 | Artur Rodrigues | <artur.rodrigues@noemail.com> |  100000.45 |            2 |
|  4 |      Bob Marley |             <bob@noemail.com> |  900000.37 |            5 |
|  5 | Mickael Jackson |         <theking@noemail.com> |    2000000 |            5 |
|  6 |   Frank Sinatra |         <sinatra@noemail.com> |  700000.67 |            5 |
|  7 |       Elon Musk |            <musk@noemail.com> |  450000.15 |            3 |
|  8 |      Steve Jobs |            <jobs@noemail.com> | 1000000.67 |            3 |
|  9 |       Lady Gaga |        <ladygaga@noemail.com> |   650000.9 |            5 |
| 10 |  Britney Spears |         <bspears@noemail.com> |   75000.56 |            5 |
| 11 |   Oprah Winfrey |           <oprah@noemail.com> | 5000000.01 |            5 |

### Select only ID Name and salary fields from the Employee table

```sql
SELECT ID, Name, Salary 
  FROM Employee
```

| ID |            Name |     Salary |
|----|-----------------|------------|
|  1 |     Jose Santos |   15000.15 |
|  2 | Leila Rodrigues |   200000.2 |
|  3 | Artur Rodrigues |  100000.45 |
|  4 |      Bob Marley |  900000.37 |
|  5 | Mickael Jackson |    2000000 |
|  6 |   Frank Sinatra |  700000.67 |
|  7 |       Elon Musk |  450000.15 |
|  8 |      Steve Jobs | 1000000.67 |
|  9 |       Lady Gaga |   650000.9 |
| 10 |  Britney Spears |   75000.56 |
| 11 |   Oprah Winfrey | 5000000.01 |

### Select all fields from employee where the Department ID equals to 5

```sql
SELECT * 
  FROM Employee
  WHERE DepartmentID = 5
```

| ID |            Name |                Email   |     Salary | DepartmentID |
|----|-----------------|------------------------|------------|--------------|
|  4 |      Bob Marley |      <bob@noemail.com> |  900000.37 |            5 |
|  5 | Mickael Jackson |  <theking@noemail.com> |    2000000 |            5 |
|  6 |   Frank Sinatra |  <sinatra@noemail.com> |  700000.67 |            5 |
|  9 |       Lady Gaga | <ladygaga@noemail.com> |   650000.9 |            5 |
| 10 |  Britney Spears |  <bspears@noemail.com> |   75000.56 |            5 |
| 11 |   Oprah Winfrey |    <oprah@noemail.com> | 5000000.01 |            5 |

### Select the Email field of all Employees of the IT and HR departments

```sql
SELECT Email 
  FROM Employee
  WHERE DepartmentID = 1 OR DepartmentID = 2
```

|                          Email |
|--------------------------------|
|    <jose.santos@noemail.com>   |
| <leila.rodrigues@noemail.com>  |
| <artur.rodrigues@noemail.com>  |

### INNER JOIN

* To select fields from two or more tables it is necessary to make a relational operation called JOIN
* A join operation uses foreign keys to relate the records
* As the Employee table has a foreign key (Department ID) from Department (ID), the select command can join the related records from both tables
* The rows on the result dataset will be mapped (linked) based on the combination of Department ID on Employee table and ID on Department table.
* In a join operation is necessary to use alias, identifiers right after the table name, to distinguish fields from different tables.

### Select all columns from Employee and Department tables

```sql
SELECT * 
  FROM Employee e
  JOIN Department d on d.ID = e.DepartmentID
```

| ID |            Name |                         Email |       Salary | DepartmentID | ID |                   Name | Abbreviation |
|----|-----------------|-------------------------------|--------------|--------------|----|------------------------|--------------|
|  2 | Leila Rodrigues | <leila.rodrigues@noemail.com> |     200000.2 |            1 |  1 |        Human Resources |           HR |
|  1 |     Jose Santos |     <jose.santos@noemail.com> |     15000.15 |            2 |  2 | Information Technology |           IT |
|  3 | Artur Rodrigues | <artur.rodrigues@noemail.com> |    100000.45 |            2 |  2 | Information Technology |           IT |
|  7 |       Elon Musk |            <musk@noemail.com> |    450000.15 |            3 |  3 |                  Sales |          SAL |
|  8 |      Steve Jobs |            <jobs@noemail.com> |   1000000.67 |            3 |  3 |                  Sales |          SAL |
|  4 |      Bob Marley |             <bob@noemail.com> |    900000.37 |            5 |  5 |              Marketing |         MARK |
|  5 | Mickael Jackson |         <theking@noemail.com> |      2000000 |            5 |  5 |              Marketing |         MARK |
|  6 |   Frank Sinatra |         <sinatra@noemail.com> |    700000.67 |            5 |  5 |              Marketing |         MARK |
|  9 |       Lady Gaga |        <ladygaga@noemail.com> |     650000.9 |            5 |  5 |              Marketing |         MARK |
| 10 |  Britney Spears |         <bspears@noemail.com> |     75000.56 |            5 |  5 |              Marketing |         MARK |
| 11 |   Oprah Winfrey |           <oprah@noemail.com> |   5000000.01 |            5 |  5 |              Marketing |         MARK |

### Select 'Employee Name' and 'Department Name' fields from Employee and Department tables

```sql
SELECT e.Name, d.Name
  FROM Employee e
  JOIN Department d on d.ID = e.DepartmentID
```

|            Name |                   Name |
|-----------------|------------------------|
| Leila Rodrigues |        Human Resources |
|     Jose Santos | Information Technology |
| Artur Rodrigues | Information Technology |
|       Elon Musk |                  Sales |
|      Steve Jobs |                  Sales |
|      Bob Marley |              Marketing |
| Mickael Jackson |              Marketing |
|   Frank Sinatra |              Marketing |
|       Lady Gaga |              Marketing |
|  Britney Spears |              Marketing |
|   Oprah Winfrey |              Marketing |

### Renaming Columns

### Select 'Employee Name' and 'Department Name' fields but renaming them to 'Employee Name' and 'Department Name' respectively

```sql
SELECT e.Name as 'Employee Name', 
       d.Name as 'Department Name'
  FROM Employee e
  JOIN Department d on d.ID = e.DepartmentID
```

|   Employee Name |        Department Name |
|-----------------|------------------------|
| Leila Rodrigues |        Human Resources |
|     Jose Santos | Information Technology |
| Artur Rodrigues | Information Technology |
|       Elon Musk |                  Sales |
|      Steve Jobs |                  Sales |
|      Bob Marley |              Marketing |
| Mickael Jackson |              Marketing |
|   Frank Sinatra |              Marketing |
|       Lady Gaga |              Marketing |
|  Britney Spears |              Marketing |
|   Oprah Winfrey |              Marketing |

### Sorting

* The ```order by``` clause sort the result set.
* The default order is ascendent, use ```DESC``` for descending order

#### Sorting Employee by Salary

```sql
SELECT FORMAT(Salary, 'N2') AS Salary, Name
  FROM Employee e
  ORDER BY e.Salary;
```

> **TIP**: Use the [FORMAT function](https://learn.microsoft.com/en-us/sql/t-sql/functions/format-transact-sql?view=sql-server-ver16) to formats a decimal value. Every SQL Server offers a lot functions

|       Salary |            Name |
|--------------|-----------------|
|    15,000.15 |     Jose Santos |
|    75,000.56 |  Britney Spears |
|   100,000.45 | Artur Rodrigues |
|   200,000.20 | Leila Rodrigues |
|   450,000.15 |       Elon Musk |
|   650,000.90 |       Lady Gaga |
|   700,000.67 |   Frank Sinatra |
|   900,000.37 |      Bob Marley |
| 1,000,000.67 |      Steve Jobs |
| 2,000,000.00 | Mickael Jackson |
| 5,000,000.01 |   Oprah Winfrey |

#### Sorting Employee by Salary in descending order

```sql
SELECT FORMAT(Salary, 'N2') as 'Salary', Name
  FROM Employee e
  ORDER BY e.Salary DESC
```

|       Salary |            Name |
|--------------|-----------------|
| 5,000,000.01 |   Oprah Winfrey |
| 2,000,000.00 | Mickael Jackson |
| 1,000,000.67 |      Steve Jobs |
|   900,000.37 |      Bob Marley |
|   700,000.67 |   Frank Sinatra |
|   650,000.90 |       Lady Gaga |
|   450,000.15 |       Elon Musk |
|   200,000.20 | Leila Rodrigues |
|   100,000.45 | Artur Rodrigues |
|    75,000.56 |  Britney Spears |
|    15,000.15 |     Jose Santos |

#### Sorting 'Employee Name' and 'Department Name' fields from Employee and Department tables

```sql
SELECT d.Name as 'Department Name',
       e.Name as 'Employee Name'
  FROM Employee e
  JOIN Department d on d.ID = e.DepartmentID
  ORDER BY d.Name, e.Name
```

* Sorting by Department and Employee Names

|        Department Name |   Employee Name |
|------------------------|-----------------|
|        Human Resources | Leila Rodrigues |
| Information Technology | Artur Rodrigues |
| Information Technology |     Jose Santos |
|              Marketing |      Bob Marley |
|              Marketing |  Britney Spears |
|              Marketing |   Frank Sinatra |
|              Marketing |       Lady Gaga |
|              Marketing | Mickael Jackson |
|              Marketing |   Oprah Winfrey |
|                  Sales |       Elon Musk |
|                  Sales |      Steve Jobs |

### LEFT, RIGHT and FULL JOIN

The default behavior of a join command (INNER JOIN) is to return only rows with data from both tables.
If it is necessary to return data from one of the tables even if there is no foreign key mapping, it is necessary to use LEFT or RIGHT join. The table in the ```FROM``` clause is the LEFT one and the table in the ```JOIN``` clause is the RIGHT one. The FULL JOIN will return records from both tables including the ones without a relation

```sql
SELECT e.Name as 'Employee Name', 
       d.Name as 'Department Name'
  FROM Employee e
  RIGHT JOIN Department d on d.ID = e.DepartmentID
```

|   Employee Name |        Department Name |
|-----------------|------------------------|
| Leila Rodrigues |        Human Resources |
|     Jose Santos | Information Technology |
| Artur Rodrigues | Information Technology |
|       Elon Musk |                  Sales |
|      Steve Jobs |                  Sales |
|          (null) |               Finances |
|      Bob Marley |              Marketing |
| Mickael Jackson |              Marketing |
|   Frank Sinatra |              Marketing |
|       Lady Gaga |              Marketing |
|  Britney Spears |              Marketing |
|   Oprah Winfrey |              Marketing |
|          (null) |       Public Relations |

* ```Employee``` is LEFT and ```Department`` is RIGHT
* Compare this result to the one from the previous example and observe that this one has two extra rows with no Employee Name for Finance Department and Public Relations.
* As there is no Employee with a Department ID equal to 4 or 5, it is necessary a RIGHT JOIN to retrieve a row for each one of those departments.

> **TIP**: Try each one of the queries below and pay good attention to the results:

```sql
SELECT e.Name as 'Employee Name', 
       d.Name as 'Department Name'
  FROM Employee e
  LEFT JOIN Department d on d.ID = e.DepartmentID

SELECT e.Name as 'Employee Name', 
       d.Name as 'Department Name'
  FROM Employee e
  RIGHT JOIN Department d on d.ID = e.DepartmentID

SELECT e.Name as 'Employee Name', 
       d.Name as 'Department Name'
  FROM Employee e
  FULL JOIN Department d on d.ID = e.DepartmentID
```

### Aggregate Functions: MAX, MIN, SUM and AVG

* MAX returns the maximum value of a field
* MIN returns the minimum value of a field
* SUM returns the sum of all values of a field
* AVG returns the average value of a field

```sql
SELECT MIN(Salary) as 'Minimum',
       MAX(Salary) as 'Maximum',
       SUM(Salary) as 'Sum',
       AVG(Salary) as 'Average'
FROM Employee
```

|  Minimum |    Maximum |         Sum |        Average |
|----------|------------|-------------|----------------|
| 15000.15 | 5000000.01 | 11090004.13 | 1008182.193636 |

### COUNT

* The COUNT clause returns the number of the records in the dataset (result of the SELECT command)

```sql
SELECT COUNT(ID) as 'Employee COUNT'
  FROM Employee
  WHERE DepartmentID = 5
```

| Employee COUNT |
|----------------|
|              6 |

### GROUP BY and COUNT

* It is possible to group the information based on a field and use a COUNT command
* The command below return a list with the Department name and the number of Employees associated with the Department

```sql
SELECT d.Name, COUNT(e.ID) as 'Employee Count'
  FROM Department d
  JOIN Employee e on e.DepartmentID = d.ID
  GROUP BY d.Name
  ORDER BY d.Name
```

|                   Name | Employee Count |
|------------------------|----------------|
|        Human Resources |              1 |
| Information Technology |              2 |
|              Marketing |              6 |
|                  Sales |              2 |

### GROUP BY and COUNT with LEFT JOIN

* It is possible to group the information based on a field and use a COUNT command
* The command below return a list with the Department name and the number of Employees associated with the Department

```sql
SELECT d.Name, COUNT(e.ID) as 'Employee Count'
  FROM Department d
  LEFT JOIN Employee e on e.DepartmentID = d.ID
  GROUP BY d.Name
  ORDER BY d.Name
```

|                   Name | Employee Count |
|------------------------|----------------|
|               Finances |              0 |
|        Human Resources |              1 |
| Information Technology |              2 |
|              Marketing |              6 |
|       Public Relations |              0 |
|                  Sales |              2 |

> **ATTENTION**: Using the left join makes sure the departments without Employees are returned.

### Group BY with Aggregate Functions

```sql
SELECT d.Name as 'Department',
       Min(e.Salary) as 'Min Salary',
       Max(e.Salary) as 'Max Salary',
       AVG(e.Salary) as 'Salary Average',
       SUM(e.Salary) as 'Salary Sum'
  FROM Department d
  LEFT JOIN Employee e on e.DepartmentID = d.ID
  GROUP BY d.Name
  ORDER BY d.Name
```

| Name                     | Min Salary   | Max Salary   | Salary Average   | Salary Sum   |
|--------------------------|--------------|--------------|------------------|--------------|
| Finances                 | NULL         | NULL         | NULL             | NULL         |
| Human Resources          | 200000.20    | 200000.20    | 200000.200000    | 200000.20    |
| Information Technology   | 15000.15     | 100000.45    | 57500.300000     | 115000.60    |
| Marketing                | 15000.15     | 5000000.01   | 1334286.094285   | 9340002.66   |
| Public Relations         | NULL         | NULL         | NULL             | NULL         |
| Sales                    | 450000.15    | 1000000.67   | 725000.410000    | 1450000.82   |

## Functions

* [SQL Functions](https://learn.microsoft.com/en-us/sql/t-sql/functions/functions?view=sql-server-ver16)
  * [String Functions](https://learn.microsoft.com/en-us/sql/t-sql/functions/string-functions-transact-sql?view=sql-server-ver16)
  * [Mathematical Function](https://learn.microsoft.com/en-us/sql/t-sql/functions/mathematical-functions-transact-sql?view=sql-server-ver16)
  * [Date & Time Functions](https://learn.microsoft.com/en-us/sql/t-sql/functions/date-and-time-data-types-and-functions-transact-sql?view=sql-server-ver16)

### String Functions

```sql
-- Length
SELECT LEN('Hello SQL Server') AS StringLength

select name, len(name) as 'Name Length'
  from Employee

-- Upper and Lower Case
SELECT UPPER('hello') AS Uppercase,
       LOWER('SQL') AS Lowercase

select upper(name), lower(name)
  from Employee

-- Substring
SELECT SUBSTRING('Microsoft SQL Server', 11, 3) AS SubString

select substring(name, 1, 5) 
  from Employee

-- Left
SELECT LEFT('Microsoft SQL Server', 9) AS 'LeftString'

select left(name, 5)
  from Employee

-- Right
SELECT RIGHT('Microsoft SQL Server', 10) AS 'LeftString'

select right(name, 5)
  from Employee

-- Replace
SELECT REPLACE('SQL is fun', 'fun', 'awesome') AS 'ReplacedString'

select name, replace(name, 'a', 'A') as 'New Name'
  from Employee

-- Concatenation
SELECT CONCAT('SQL', ' ', 'Server') AS 'ConcatenatedString'

select concat('[', name, ':', email, ';', salary, ']') As 'NameEmail'
  from Employee

select concat(name, ' length is ', len(name))
  from Employee

select name as 'FullName',
       left(name, CHARINDEX (' ', name)) as 'First Name'
  from Employee

-- Reverse
SELECT REVERSE('ABCDEFGHIJKLM') AS 'ReversedString'

select name as 'FullName',
       REVERSE(name) as 'Reversed Name'
  from Employee

-- First Name
select name as 'FullName',
       left(name, CHARINDEX (' ', name) - 1) as 'First Name'
  from Employee

-- Last Name
select name as 'FullName',
       reverse(left(reverse(name), CHARINDEX (' ', reverse(name)) - 1)) as 'Last Name'
  from Employee
```

### Math Functions

```sql
SELECT 
  ABS(-15) AS AbsoluteValue,
  POWER(2, 3) AS PowerResult,
  ROUND(123.456, 2) AS RoundedNumber,
  SQRT(16) AS SquareRoot,
  CEILING(4.2) AS CeilingResult,
  FLOOR(4.7) AS FloorResult
```

### Date/Time Functions

```sql
SELECT GETDATE() AS CurrentDateTime

SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'),
       FORMAT(GETDATE(), 'yyyy/MM/dd'),
       FORMAT(GETDATE(), 'MM/dd/yyyy'),
       FORMAT(GETDATE(), 'dd/MM/yyyy'),
       FORMAT(GETDATE(), 'yyyy-MM-dd hh:mm:ss')

SELECT GETDATE(), DATEADD(DAY, 15, GETDATE()),
       GETDATE(), DATEADD(MONTH, 6, GETDATE()),
       GETDATE(), DATEADD(YEAR, 2, GETDATE())

SELECT DATEDIFF(DAY, '1972-03-25', GETDATE()),
       DATEDIFF(MONTH, '1972-03-25', GETDATE()),
       DATEDIFF(YEAR, '1972-03-25', GETDATE())

SELECT YEAR(GETDATE()), 
       MONTH(GETDATE()), 
       DAY(GETDATE());

SELECT DATEPART(YEAR, GETDATE()),
       DATEPART(MONTH, GETDATE()),
       DATEPART(DAY, GETDATE())

SELECT EOMONTH(GETDATE()),
       EOMONTH('2025-02-01'),
       EOMONTH('2028-02-01')
```

## Sample Databases

Microsoft provides several excellent sample databases for practicing SQL commands.

### 1. AdventureWorks

This database simulates a multinational manufacturing company and includes a comprehensive schema with tables for:

* Products
* Sales
* Purchasing
* Production
* Human Resources

It's ideal for learning advanced SQL concepts like:

* Stored procedures
* Triggers
* Indexing

### 2. Wide World Importers

Designed for SQL Server 2016 and later, this database includes both OLTP (Online Transaction Processing) and OLAP (Online Analytical Processing) versions. It showcases modern database design techniques and is great for exploring features like:

* JSON support
* Temporal tables

### 3. Northwind

A classic database that represents a small business selling food and beverages. It's simpler than AdventureWorks and is perfect for beginners.

### Documentation

* You can find these databases on Microsoft's [SQL Server samples GitHub repository](https://learn.microsoft.com/en-us/sql/samples/sql-samples-where-are?view=sql-server-ver16) or other trusted sources.
* <https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs>

### NorthWind Sample Database

#### Data Model Diagram

![Application Architecture](/SQL/images/NorthwindDMDiagram.png)

#### Queries

```sql
select ProductName, UnitPrice, UnitsInStock,
       CategoryName,
      CompanyName, ContactName, Phone
  from Products p
  inner join Categories c on c.CategoryID = p.CategoryID
  inner join Suppliers s on s.SupplierID = p.SupplierID
  where UnitsInStock <= 5

select c.CategoryName, count(ProductID)
  from Categories c
  left join Products p on p.CategoryID = c.CategoryID
  group by c.CategoryName

select CONCAT(FirstName, ' ', LastName) as FullName,
  t.TerritoryDescription,
  r.RegionDescription
  from Employees e
  inner join EmployeeTerritories et on et.EmployeeID = e.EmployeeID
  inner join Territories t on t.TerritoryID = et.TerritoryID
  inner join Region r on r.RegionID = t.RegionID

-- Orders for a specific customer
select o.OrderID, FORMAT(o.OrderDate,'MM-dd-yyyy') as 'Order Date',
       p.ProductName,
       od.Quantity, od.UnitPrice, od.Quantity * od.UnitPrice as 'Total Price'
  from Orders o
  inner join [Order Details] od on od.OrderID = o.OrderID
  inner join Products p on p.ProductID = od.ProductID
  where o.CustomerID = 'ANTON'
  order by o.OrderID

-- Homework: Craete a query to list employees per region
```

## More on Data Modeling

Data modeling is the process of defining and organizing data elements and their relationships for a specific purpose, usually within a database. It helps to:

* Structure data efficiently.
* Ensure data integrity.
* Simplify database management.

### Types of Data Models

#### 1. **Conceptual Data Model**

* High-level representation of the data.
* Focuses on **what** data is required and its relationships.
* Example: Entity-Relationship Diagram (ERD).

#### 2. **Logical Data Model**

* Detailed blueprint of data structure.
* Focuses on **how** data should be organized.
* Example: Defining attributes, data types, and primary/foreign keys.

#### 3. **Physical Data Model**

* Actual implementation of the database.
* Focuses on **how and where** data is stored.
* Example: Tables, columns, indexes, and storage settings.

### Components of a Data Model

* **Entities**:  Objects or concepts that store data (e.g., "Student", "Course").

* **Attributes**: Properties or characteristics of an entity (e.g., "Name", "Age").

* **Relationships**: Connections between entities (e.g., "Student enrolls in Course").

### Example: Entity-Relationship Diagram (ERD)

#### Entities

* **Student** (attributes: StudentID, Name, Age).

* **Course** (attributes: CourseID, Title, Credits).

#### Relationship

* A *Student* can enroll in multiple *Courses*.

### Benefits of Data Modeling

* Improves data quality and consistency.
* Enhances communication between stakeholders.
* Provides a clear blueprint for database developers.

### Tools for Data Modeling

* [Lucidchart](https://www.lucidchart.com)
* [Draw.io](https://app.diagrams.net)
* [Microsoft Visio](https://www.microsoft.com/en-us/microsoft-365/visio/flowchart-software)
* [MySQL Workbench](https://www.mysql.com/products/workbench/)
* [MS SQL Server Management Studio](https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms)

### Summary

Data modeling is a fundamental step in designing effective databases. It provides a clear structure to manage and retrieve data efficiently, laying the groundwork for successful database implementation.

## Indexes

Indexes in SQL Server are database objects that improve the speed of data retrieval operations on a table by providing quick access to rows.
They function like the index of a book, allowing the database engine to find information without scanning the entire table.

### **How Index Works**

![Index](images/HowIndexWorks.png)

### **Types of Indexes**

1. **Clustered Index**
   * Sorts and stores data rows in the table based on the index key.
   * A table can have only one clustered index.
   * SQL Server doesn’t create a separate structure a clustered index.
     Instead, the table itself becomes the index.
   * Example:

     ```sql
     CREATE CLUSTERED INDEX INDEX_NAME
     ON TABLE_NAME(FIELDS_LIST);
     ```

2. **Non-Clustered Index**
   * Creates a separate structure from the table data, with a pointer to the actual data rows.
   * A table can have multiple non-clustered indexes.
   * Example:

     ```sql
     CREATE NONCLUSTERED INDEX INDEX_NAME
     ON TABLE_NAME(FIELDS_LIST);
     ```

3. **Unique Index**
   * Ensures all values in the index key are unique.
   * Can be clustered or non-clustered.
   * Example:

     ```sql
     CREATE UNIQUE NONCLUSTERED INDEX INDEX_NAME
     ON TABLE_NAME(FIELDS_LIST);
     ```

### **Advantages of Indexes**

* Speeds up SELECT queries and improves search performance.
* Helps enforce constraints like UNIQUE and PRIMARY KEY.
* Reduces disk I/O operations during data retrieval.
* We don't need o specify indexes for queries, the DBMS automatically decide which indexes to use

### **Considerations When Using Indexes**

* **Performance Cost**: Indexes slow down INSERT, UPDATE, and DELETE operations as the index needs to be updated.
* **Storage Requirement**: Indexes consume additional storage space.
* **Maintenance**: Indexes should be rebuilt or reorganized periodically to ensure optimal performance.

### Index Management

* View Existing Indexes

   ```sql
   SELECT * 
   FROM sys.indexes 
   WHERE object_id = OBJECT_ID('TABLE_NAME');

* Rebuild Indexes

  ```sql
  ALTER INDEX INDEX_NAME ON TABLE_NAME REBUILD;
  ```

* Delete Index

  ```sql
  DROP INDEX INDEX_NAME ON TABLE_NAME;
  ```

* Monitor Index Usage

  ```sql
    SELECT * 
      FROM sys.dm_db_index_usage_stats 
      WHERE database_id = DB_ID('DATABASE_NAME');
  ```

## Advanced Queries

* Create table only if does NOT exist

  ```sql
  IF NOT EXISTS (
      SELECT * 
      FROM INFORMATION_SCHEMA.TABLES 
      WHERE TABLE_NAME = 'Region'
  )
  BEGIN
      CREATE TABLE Region (
          RegionID INT PRIMARY KEY,
          RegionDescription NVARCHAR(50)
      );
  END;
  ```

* Return only the Top N rows

  ```sql
  SELECT TOP 5 p.ProductID, p.ProductName
  FROM Products p

  SELECT TOP 5 ProductID, ProductName, UnitPrice
  FROM Products
  ORDER BY UnitPrice
  ```

* Filtering using LIKE

  ```sql
  SELECT * FROM products
  WHERE ProductName like 'Louis%'

  SELECT * FROM products
  WHERE ProductName like '%ing'

  SELECT * FROM products
  WHERE ProductName like '%org%'
  ```

* Filtering using BETWEEN

  ```sql
  SELECT * FROM products
  WHERE UnitPrice BETWEEN 20 AND 30
  ```

* Filtering by date

  ```sql
  SELECT *
  FROM Orders
  WHERE OrderDate > '1998-03-01'
  ORDER BY OrderDate

  SELECT *
  FROM Orders
  WHERE OrderDate >= '1998-03-01' AND OrderDate <= '1998-03-31'
  ORDER BY OrderDate

  SELECT *
  FROM Orders
  WHERE OrderDate BETWEEN '1998-03-01' AND '1998-03-31'
  ORDER BY OrderDate
  ```

* Filtering using IN

  ```sql
  SELECT * FROM products
  WHERE CategoryID in (2, 4, 7)

  SELECT * FROM Orders
  WHERE CustomerID IN (SELECT CustomerID FROM Customers WHERE City = 'Sao Paulo')

  SELECT CustomerID, CompanyName
  FROM Customers
  WHERE CustomerID IN (
      SELECT CustomerID
      FROM Orders
      WHERE ShipVia = 1
  )

  SELECT c.CustomerID, c.CompanyName
  FROM Customers c
  WHERE c.CustomerID NOT IN (
      SELECT DISTINCT o.CustomerID
      FROM Orders o
  )
  ```

* Comparing to NULL
  > ⚠️ **Warning**: Direct Comparison (= or !=) with NULL does NOT work, use IS or IS NOT NULL

  ```sql
  SELECT EmployeeID, FirstName, LastName, ReportsTo
  FROM Employees
  WHERE ReportsTo IS NULL

  SELECT EmployeeID, FirstName, LastName, ReportsTo
  FROM Employees
  WHERE ReportsTo IS NOT NULL

  -- NEVER use = OR != when testing for NULL
  SELECT EmployeeID, FirstName, LastName, ReportsTo
  FROM Employees
  WHERE ReportsTo = NULL

  SELECT EmployeeID, FirstName, LastName, ReportsTo
  FROM Employees
  WHERE ReportsTo != NULL

  ```

* Queries with multiple joins

  ```sql
  SELECT 
      o.OrderID,
      o.OrderDate,
      c.CustomerID,
      c.CompanyName AS CustomerName,
      e.EmployeeID,
      e.FirstName + ' ' + e.LastName AS EmployeeName,
      s.ShipperID,
      s.CompanyName AS ShipperName,
      od.ProductID,
      p.ProductName,
      od.Quantity,
      od.UnitPrice,
      od.Discount,
      sup.SupplierID,
      sup.CompanyName AS SupplierName,
      cat.CategoryID,
      cat.CategoryName
  FROM Orders o
  JOIN Customers c ON o.CustomerID = c.CustomerID
  JOIN Employees e ON o.EmployeeID = e.EmployeeID
  JOIN [Order Details] od ON o.OrderID = od.OrderID
  JOIN Products p ON od.ProductID = p.ProductID
  JOIN Suppliers sup ON p.SupplierID = sup.SupplierID
  JOIN Categories cat ON p.CategoryID = cat.CategoryID
  JOIN Shippers s ON o.ShipVia = s.ShipperID;
  ```

* Using left/right join to return rows without relationship

  ```sql
  SELECT c.CustomerID, c.CompanyName
  FROM Customers c
  LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
  WHERE o.CustomerID IS NULL
  ```

* Rank Employees by Sales Using Window Functions

  ```sql
  SELECT e.EmployeeID, e.FirstName, e.LastName,
        FORMAT(SUM(od.Quantity * od.UnitPrice),'N2') AS TotalSales,
        RANK() OVER (ORDER BY SUM(od.Quantity * od.UnitPrice) DESC) AS SalesRank
  FROM Employees e
  JOIN Orders o ON e.EmployeeID = o.EmployeeID
  JOIN [Order Details] od ON o.OrderID = od.OrderID
  GROUP BY e.EmployeeID, e.FirstName, e.LastName;
  ```

* Identify Customers with Orders Above a Certain Amount

  ```sql
  SELECT c.CustomerID, c.CompanyName,
        SUM(od.Quantity * od.UnitPrice) AS TotalOrderAmount
  FROM Customers c
  JOIN Orders o ON c.CustomerID = o.CustomerID
  JOIN [Order Details] od ON o.OrderID = od.OrderID
  GROUP BY c.CustomerID, c.CompanyName
  HAVING SUM(od.Quantity * od.UnitPrice) > 15000;
  ```

* Find Top 5 Products by Revenue

  ```sql
  SELECT TOP 5 p.ProductID, p.ProductName,
        SUM(od.Quantity * od.UnitPrice) AS TotalRevenue
  FROM Products p
  JOIN [Order Details] od ON p.ProductID = od.ProductID
  GROUP BY p.ProductID, p.ProductName
  ORDER BY TotalRevenue DESC;

  ```

* List Orders with Details in JSON Format

  ```sql
  SELECT o.OrderID, o.CustomerID, o.EmployeeID, o.OrderDate
  FROM Orders o
  FOR JSON PATH;

  SELECT o.OrderID,
        (SELECT od.ProductID, od.Quantity, od.UnitPrice
          FROM [Order Details] od
          WHERE o.OrderID = od.OrderID
          FOR JSON PATH) AS OrderDetailsJSON
  FROM Orders o;
  ```

## Database Transactions

A **transaction** in a database is a sequence of operations performed as a single unit of work.
The key idea is that either **all operations** within a transaction succeed or **none** do,
ensuring consistency.

### Transactions follow the **ACID properties**

1. **Atomicity**: All operations in a transaction complete successfully, or none of them do.
2. **Consistency**: The database moves from one valid state to another.
3. **Isolation**: Transactions do not interfere with each other.
4. **Durability**: Once a transaction is committed, it is permanently recorded.

### SQL Server Transaction implementation

In SQL server the commands below are used to manage transactions

* BEGIN TRAN  : initialize a transaction
* COMMIT      : finalize the transaction confirming all commands
* ROLL BACK   : cancel the transaction undoing all executed commands

```sql
BEGIN TRAN

-- SQL COMMANDS

COMMIT -- If everything is good

ROLLBACK -- If the transaction failed
```

### Links

* [SQL Server Transaction](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/transactions-transact-sql?view=sql-server-ver16)
* [SQL Server, Locks object](https://learn.microsoft.com/en-us/sql/relational-databases/performance-monitor/sql-server-locks-object?view=sql-server-ver16)
* [Server configuration: locks](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/configure-the-locks-server-configuration-option?view=sql-server-ver16)

### Example: Bank Transactions

The most typical example of database transaction: Bank account transfer operation.

### Account table

  ```sql
  CREATE TABLE Account (
      id INT PRIMARY KEY,
      account_number INT NOT NULL,
      balance DECIMAL(10, 2) NOT NULL
  );

  INSERT INTO Account (id, account_number, balance)
  VALUES (1, 123456, 1000.00),
         (2, 654321, 2000.00);
  ```

### Transfer Transaction

  ```sql
  DECLARE @SourceAccount INT = 123456;  -- Source Account
  DECLARE @TargetAccount INT = 654321;  -- Target Account
  DECLARE @TransferAmount DECIMAL(10, 2) = 200.00; -- Amount to transfer
    
  BEGIN TRANSACTION

  -- Withdraw from souce account
  UPDATE Account
    SET balance = balance - @TransferAmount
    WHERE account_number = @SourceAccount;
  -- Deposit into target account
  UPDATE Account
    SET balance = balance + @TransferAmount
    WHERE account_number = @TargetAccount
  -- Commit the transaction

  COMMIT
  -- ROLLBACK

  PRINT 'Transaction Successful!'
  ```

## How SQL Server Implements Transactions

SQL Server ensures reliable and consistent transaction management by adhering to the ACID properties through several mechanisms:

### 1. Transaction Log

* SQL Server maintains a **transaction log** that records every modification made during a transaction.
* This log ensures **Durability**, as committed transactions can be recovered even in case of a crash.

### 2. Locks

* **Locks** are used to enforce **Isolation**, preventing conflicts between simultaneous transactions.
* SQL Server applies different types of locks (shared, exclusive, etc.) based on the operation being performed.

### 3. Write-Ahead Logging (WAL)

* Changes are written to the transaction log **before** being applied to the database.
* This principle ensures **Atomicity**, allowing rollback if a failure occurs mid-transaction.

### 4. TempDB Usage

* SQL Server uses the `tempdb` system database for temporary storage during operations such as sorting or versioning.
* This is especially relevant in **Snapshot Isolation**, where versioned data is stored temporarily.

### 5. Savepoints

* Users can define **savepoints** within a transaction, which act as checkpoints.
* Savepoints allow partial rollbacks without undoing the entire transaction.

### 6. Isolation Levels

* SQL Server provides multiple **isolation levels** (e.g., Read Committed, Serializable, Snapshot) to control how transactions interact.
* Each level balances **Isolation** and performance differently.

### 7. Automatic Rollback on Failure

* If an error occurs, SQL Server automatically rolls back the transaction to maintain **Consistency**.
* This prevents partial updates from corrupting the database state.

### 8. Concurrency Control

* SQL Server uses **locking** and **versioning** strategies to manage concurrent transactions.
* These mechanisms ensure efficiency while upholding the ACID properties.

### Query WITH(NOLOCK)

If rows are participating in transactions, the database lock access to it until the transaction is completed.
the WITH(NOLOCK) option allow the access of lines particating in trasactions

  ```sql
  SELECT *
    FROM ACCOUNT WITH(NOLOCK) -- Ignoring the transaction locking
  ```

## CTE

## Transaction SQL (TSQL)

* [Reference](https://learn.microsoft.com/en-us/sql/t-sql/language-reference?view=sql-server-ver16)

## Stored Procedure

* [Documentation](https://learn.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure?view=sql-server-ver16)

## Triggers

* [Documentation](https://learn.microsoft.com/en-us/sql/t-sql/statements/create-trigger-transact-sql?view=sql-server-ver16)
