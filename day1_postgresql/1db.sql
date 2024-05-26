-- Create New Table
CREATE TABLE customer (
   customer_id serial PRIMARY KEY,
   first_name character varying(100) NOT NULL,
   last_name character varying(100) NOT NULL,
   email character varying(255) UNIQUE NOT NULL,
   created_date timestamp with time zone NOT NULL DEFAULT now(),
   updated_date timestamp with time zone
);

-- Drop Table
DROP TABLE IF EXISTS customer;

-- Add New Column
ALTER TABLE customer ADD COLUMN active boolean;

-- Drop New Column
ALTER TABLE customer DROP COLUMN active;

-- After Delete Column - Select Statement
SELECT * from customer

-- Rename Existing Column
ALTER TABLE customer RENAME COLUMN fist_name TO first_name;

-- After Rename Column - Select Statement
SELECT * from customer

ALTER TABLE customer RENAME COLUMN email_address TO email;

-- Rename table name
ALTER TABLE customer RENAME TO users;

ALTER TABLE users RENAME TO customer;

-- Create New Orders Table
CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
    order_date timestamp with time zone NOT NULL DEFAULT now(),
    order_number CHARACTER VARYING(50) NOT NULL,
    order_amount DECIMAL(10,2) NOT NULL
);

-- Insert Single Customer Record
INSERT INTO customer(first_name, last_name, email_addres, created_date, updated_date, active)
	VALUES ('Hiren','Patel','hiren.parejiya@tatvasoft.com',now(),NULL,true);
INSERT INTO customer (first_name, last_name, email_addres, created_date, updated_date,active) VALUES
  ('John', 'Doe', 'johndoe@example.com', NOW(), NULL,true),
  ('Alice', 'Smith', 'alicesmith@example.com', NOW(), NULL,true),
  ('Bob', 'Johnson', 'bjohnson@example.com', NOW(), NULL,true),
  ('Emma', 'Brown', 'emmabrown@example.com', NOW(), NULL,true),
  ('Michael', 'Lee', 'michaellee@example.com', NOW(), NULL,false),
  ('Sarah', 'Wilson', 'sarahwilson@example.com', NOW(), NULL,true),
  ('David', 'Clark', 'davidclark@example.com', NOW(), NULL,true),
  ('Olivia', 'Martinez', 'oliviamartinez@example.com', NOW(), NULL,true),
  ('James', 'Garcia', 'jamesgarcia@example.com', NOW(), NULL,false),
  ('Sophia', 'Lopez', 'sophialopez@example.com', NOW(), NULL,false),
  ('Jennifer', 'Davis', 'jennifer.davis@example.com', NOW(), NULL,true),
  ('Jennie', 'Terry', 'jennie.terry@example.com', NOW(), NULL,true),
  ('JENNY', 'SMITH', 'jenny.smith@example.com', NOW(), NULL,false),
  ('Hiren', 'Patel', 'hirenpatel@example.com', NOW(), NULL,false);

INSERT INTO orders (customer_id, order_date, order_number, order_amount) VALUES
  (1, '2024-01-01', 'ORD001', 50.00),
  (2, '2024-01-01', 'ORD002', 35.75),
  (3, '2024-01-01', 'ORD003', 100.00),
  (4, '2024-01-01', 'ORD004', 30.25),
  (5, '2024-01-01', 'ORD005', 90.75),
  (6, '2024-01-01', 'ORD006', 25.50),
  (7, '2024-01-01', 'ORD007', 60.00),
  (8, '2024-01-01', 'ORD008', 42.00),
  (9, '2024-01-01', 'ORD009', 120.25),
  (10,'2024-01-01', 'ORD010', 85.00),
  (1, '2024-01-02', 'ORD011', 55.00),
  (1, '2024-01-03', 'ORD012', 80.25),
  (2, '2024-01-03', 'ORD013', 70.00),
  (3, '2024-01-04', 'ORD014', 45.00),
  (1, '2024-01-05', 'ORD015', 95.50),
  (2, '2024-01-05', 'ORD016', 27.50),
  (2, '2024-01-07', 'ORD017', 65.75),
  (2, '2024-01-10', 'ORD018', 75.50);

SELECT customer_id, first_name, last_name, email_addres, created_date, updated_date, active
FROM customer;

UPDATE customer
SET first_name='yash',
last_name='sankadasariya', 
email_addres='yash@gmail.com'
WHERE customer_id = 1;

DELETE FROM customer
WHERE customer_id = 11;

SELECT first_name FROM customer;

SELECT
   first_name,
   last_name,
   email_addres
FROM
   customer;

SELECT * FROM customer;

SELECT
	first_name,
	last_name
FROM
	customer
ORDER BY
	first_name ASC;

SELECT
       first_name,
       last_name
FROM
       customer
ORDER BY
       last_name DESC;

SELECT
	customer_id,
	first_name,
	last_name
FROM
	customer
ORDER BY
	first_name ASC,
	last_name DESC;

SELECT
	last_name,
	first_name
FROM
	customer
WHERE
	first_name = 'yash';

SELECT
	customer_id,
	first_name,
	last_name
FROM
	customer
WHERE
	first_name = 'yash' AND last_name = 'sankadasariya';
SELECT
	customer_id,
	first_name,
	last_name
FROM
	customer
WHERE first_name IN ('John','David','James');

SELECT
	first_name,
    last_name
FROM
	customer
WHERE
	first_name LIKE '%sh%';

SELECT
	first_name,
    last_name
FROM
	customer
WHERE
	first_name ILIKE '%EN%';

SELECT * FROM orders as o
INNER JOIN customer as c
ON o.customer_id = c.customer_id

select * FROM customer as c
LEFT JOIN orders as o
ON c.customer_id = o.customer_id

SELECT
	c.customer_id,
	c.first_name,
	c.last_name,
	c.email_addres,
	COUNT (o.order_id) AS "NoOrders",
	SUM(o.order_amount) AS "Total"
FROM customer as c
INNER JOIN orders as o
	ON c.customer_id = o.customer_id
GROUP BY c.customer_id

SELECT
	c.customer_id,
	c.first_name,
	c.last_name,
	c.email_addres,
	COUNT (o.order_id) AS "No_Orders",
	SUM(o.order_amount) AS "Total"
FROM customer as c
INNER JOIN orders as o
	ON c.customer_id = o.customer_id
GROUP BY c.customer_id
HAVING COUNT (o.order_id) > 1

SELECT * from orders
where customer_id IN (select customer_id from customer where active = true)

SELECT
    customer_id,
	first_name,
	last_name,
	email_addres
FROM
	customer
WHERE
	EXISTS (
		SELECT
			1
		FROM
			orders
		WHERE
			orders.customer_id = customer.customer_id
	);