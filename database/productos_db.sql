SET NAMES utf8mb4;
DROP DATABASE IF EXISTS productos_db;
CREATE DATABASE productos_db;
USE productos_db;

CREATE TABLE productos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL
);

INSERT INTO productos (nombre, precio, stock) VALUES
('Laptop', 12999.00, 10),
('Mouse', 249.90, 50),
('Teclado', 899.00, 25);
