CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    cars(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        make VARCHAR(255) NOT NULL,
        year INT NOT NULL,
        price DOUBLE NOT NULL,
        model VARCHAR(255) NOT NULL,
        description TEXT,
        color VARCHAR(10),
        imgUrl VARCHAR(255),
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
    ) default charset utf8mb4 COMMENT "for the emojis";

CREATE TABLE
    houses(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(255) NOT NULL,
        imgUrl VARCHAR(255),
        price DOUBLE NOT NULL,
        sqft DOUBLE NOT NULL,
        description TEXT,
        year INT NOT NULL,
        bedrooms INT NOT NULL,
        bathrooms INT NOT NULL
    ) default charset utf8mb4 COMMENT "for the emojis";

DROP TABLE houses;