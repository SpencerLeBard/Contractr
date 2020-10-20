/* SCHEMA using 'CREATE TABLE', this is only done manually at the very start of the application or if you need a "fresh" database */

/* DANGER THIS WILL DESTROY THE TABLE AND ALL ITS DATA PERMENANTLY */
/* DROP TABLE contractor; */

-- CREATE TABLE contractor
-- ( 
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   price DECIMAL(6, 2) NOT NULL,

--   PRIMARY KEY (id)
-- );

/* POST */
-- INSERT INTO contractor (location, description) VALUES ("Seattle", "water everywhere");


/* GET ALL */
/* SELECT * FROM contractor; */

/* GET BY _____ */
-- SELECT * FROM contractor WHERE id = 2;
/* SELECT * FROM contractor WHERE title LIKE "Plum%"; */


/* PUT */
/* UPDATE contractor
SET
  title = "Squatty Potty Deluxe",
  description = "Helps you loo",
  price = 34.92
WHERE id = 1; */

/* SELECT * from contractor; */

/* DELETE */
/* DELETE FROM contractor WHERE title LIKE "Plum%";
SELECT * FROM contractor; */