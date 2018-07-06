CREATE TABLE IF NOT EXISTS items (
	id INT PRIMARY KEY,
	slot STRING NOT NULL,
	name STRING NOT NULL,
	brand STRING,
	type STRING NOT NULL,
	created DATETIME NOT NULL,
	purchased DATETIME,
	notes STRING,
	material STRING,
	pattern STRING,
	size STRING,
	sleevelength STRING,
	price DECIMAL,
	formality STRING,
	fit STRING,
	wear STRING,
	warmth STRING
);

CREATE TABLE IF NOT EXISTS outfits (
	id INT PRIMARY KEY,
	name STRING NOT NULL,
	type STRING NOT NULL,
	created DATETIME NOT NULL,
	notes STRING
);

CREATE TABLE IF NOT EXISTS colors (
	id INT PRIMARY KEY,
	item INT,
	name STRING NOT NULL,
	hex INT NOT NULL,
	FOREIGN KEY(item) REFERENCES items(id)
);

CREATE TABLE IF NOT EXISTS slots (
	id INT PRIMARY KEY,
	name STRING NOT NULL,
	outfit INT,
	item INT,
	FOREIGN KEY(outfit) REFERENCES outfits(id),
	FOREIGN KEY(item) REFERENCES items(id)
);