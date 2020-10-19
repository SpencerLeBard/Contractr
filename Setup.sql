create table contractor 
(
  id INT NOT NULL AUTO_INCREMENT,
  location VARCHAR(225) NOT NULL,
  description VARCHAR(225),

  PRIMARY KEY(id)
);

/* POST */
INSERT INTO contractor (location, description) VALUES ("Eagle", "fix door");
INSERT INTO contractor (location, description) VALUES ("Nampa", "Gets that Itch");
INSERT INTO contractor (location, description) VALUES ("Boise", "plum toilet");

/*GET ALL*/
SELECT * FROM contractor;

/*GET BY _____ */
SELECT * FROM contractor WHERE id = 2;
SELECT * FROM contractor WHERE location LIKE "ea%";