--select uid,title from TitleBook where uid=2 or uid = 3 

SELECT COUNT(id), title
FROM TitleBook
GROUP BY title
HAVING COUNT(uid) > 0;

