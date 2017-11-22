CREATE DATABASE mama;

USE mama;

CREATE TABLE categories (
id          INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
name        VARCHAR(20)
);

CREATE TABLE category_task (
category_id INT UNSIGNED NOT NULL REFERENCES categories(id),
task_id     INT UNSIGNED NOT NULL REFERENCES tasks(id)
);

CREATE TABLE tasks (
id          INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
user_id     INT UNSIGNED NOT NULL REFERENCES user(id),
name        VARCHAR(20)  NOT NULL,
description TEXT,
state       ENUM('inactive', 'active', 'finished') NOT NULL DEFAULT 'inactive'
);

CREATE TABLE category_user (
category_id INT UNSIGNED NOT NULL REFERENCES categories(id),
user_id     INT UNSIGNED NOT NULL REFERENCES users(id)
);

CREATE TABLE users (
id       INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
name     VARCHAR(30)  NOT NULL UNIQUE,
mail     VARCHAR(30)  NOT NULL UNIQUE,
password VARCHAR(30)  NOT NULL
);

