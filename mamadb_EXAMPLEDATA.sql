-- EXAMPLE DATA AND QUERIES

USE mama;

-- USERS --
INSERT INTO users (name, mail, password)
VALUES
('Rick Sanchez', 'c-137@RickCitadel.rc', 'Wubba-lubba-dub-dub'),
('Argus Filch', 'afilch@hoggy.pl', 'alamakota17'),
('Jon Snow', 'JSnow@north.westr', 'Winter came'),
('Jarek', 'mckwacz@zgin.plo', 'Zimny lech'),
('Castor Troy', 'iamgodbaby@somedomain.la', 'peach');

SHOW WARNINGS;
-----------

-- CATEGORIES --
INSERT INTO categories (name)
VALUES
('Cleaning'),
('Administration'),
('Security'),
('Accountancy'),
('Rubout'),
('Science');

SHOW WARNINGS;
----------------

-- USERS_CATEGORIES --
-- example queries
-- eg1 (note: subqueries must return exactly 1 row)
INSERT INTO users_categories (uid, cid)
VALUES
((SELECT id FROM users WHERE name = 'Rick Sanchez'), (SELECT id FROM categories WHERE name = 'Science'));
SHOW WARNINGS;
-- eg2
INSERT INTO users_categories (uid, cid)
SELECT u.id, c.id
FROM users u, categories c
WHERE u.name = 'Jarek'
AND (c.name = 'Szkodnik'
OR   c.name = 'Administration'
OR   c.name = 'Accountancy');
SHOW WARNINGS;
-- eg3
SELECT id INTO @uid FROM users      WHERE name = 'Argus Filch';
SELECT id INTO @cid FROM categories WHERE name = 'Cleaning';
INSERT INTO users_categories (uid, cid)
VALUES (@uid, @cid);
SHOW WARNINGS;
-- nonexample queries: assign rest of crew...
INSERT INTO users_categories (uid, cid)
SELECT u.id, c.id
FROM users u, categories c
WHERE (u.name = 'Jon Snow' AND c.name = 'Security')
OR (u.name = 'Castor Troy' AND c.name = 'Rubout');

SHOW WARNINGS;

-- TASKS --
-- method below isn't good performance wise
-- it would be better to SELECT name, id FROM users -> array; set author_id using array
INSERT INTO tasks (author_id, name, description)
VALUES
((SELECT id FROM users WHERE name = 'Jarek'), 'Make me lord of Poland', 'Title says it all.'),
((SELECT id FROM users WHERE name = 'Jon Snow'), 'New sword', 'Features of the sword: burning, life leach, out of Dragon glass (thus burning), self repairing and undestructable.'),
((SELECT id FROM users WHERE name = 'Jarek'), 'Feed my cat', NULL),
((SELECT id FROM users WHERE name = 'Rick Sanchez'), 'Clean up toilet', 'Floor is pissy.'),
((SELECT id FROM users WHERE name = 'Argus Filch'), 'Funds for soap needed.', 'Each sope 20 Knuts each.'),
((SELECT id FROM users WHERE name = 'Jarek'), 'Destroy PO', 'Make blood rain.');
-----------

SHOW WARNINGS;

-- TASKS_CATEGORIES --
INSERT INTO tasks_categories (tid, cid)
SELECT t.id, c.id
FROM tasks t, categories c
WHERE (t.name = 'Make me lord of Poland' AND c.name = 'Security')
OR (t.name = 'Make me lord of Poland' AND c.name = 'Rubout')
OR (t.name = 'Make me lord of Poland' AND c.name = 'Science')
OR (t.name = 'New sword' AND c.name = 'Science')
OR (t.name = 'Feed my cat' AND c.name = 'Cleaning')
OR (t.name = 'Clean up toilet' AND c.name = 'Cleaning')
OR (t.name = 'Funds for soap needed.' AND c.name = 'Administration')
OR (t.name = 'Funds for soap needed.' AND c.name = 'Accountancy')
OR (t.name = 'Destroy PO' AND c.name = 'Rubout')
OR (t.name = 'Destroy PO' AND c.name = 'Science');
----------------------

SHOW WARNINGS;

