/* SCHEMA using 'CREATE TABLE', this is only done manually at the very start of the application or if you need a "fresh" database */

/* DANGER THIS WILL DESTROY THE TABLE AND ALL ITS DATA PERMENANTLY */
/* DROP TABLE contractor; */

-- CREATE TABLE jobs
-- ( 
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   address VARCHAR(255),
--   skills VARCHAR(255),

--   PRIMARY KEY (id)
-- );

/* POST */
-- INSERT INTO jobs (name, address, skills) VALUES ("Spencer", "Boise92829", "supafly");
-- INSERT INTO jobs (name, address, skills) VALUES ("Hank", "Mangy", "Trasient");


/* GET ALL */
-- SELECT * FROM jobs;

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