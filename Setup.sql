/* SCHEMA using 'CREATE TABLE', this is only done manually at the very start of the application or if you need a "fresh" database */

/* DANGER THIS WILL DESTROY THE TABLE AND ALL ITS DATA PERMENANTLY */
/* DROP TABLE contractor; */

-- CREATE TABLE reviews
-- ( 
--   id INT AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,
--   rating INT,
--   datee VARCHAR(255),
--   ContractorId INT,

--     INDEX (ContractorId),

--     PRIMARY KEY (id),
--     FOREIGN KEY (ContractorId)
--     REFERENCES reviews (id)
--     ON DELETE CASCADE
-- );

/* POST */
-- INSERT INTO reviews (title, body, rating, datee, ContractorId) VALUES ("help", "please", 5, "07/", 1);
-- INSERT INTO reviews (title, body, rating, datee, ContractorId) VALUES ("godhelp", "prettyplease", 5, "datataa", 1 );


/* GET ALL */
SELECT * FROM reviews;

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