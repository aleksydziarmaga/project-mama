USE mama;

SELECT id, name FROM users ORDER BY id;
SELECT id, name FROM categories ORDER BY id;
SELECT id, name FROM tasks ORDER BY id;
SELECT *        FROM users_categories ORDER BY uid, cid;
SELECT *        FROM tasks_categories ORDER BY tid, cid;

