
-- количество клиентов, совершивших первую покупку через 0-5 дней после регистрации.
SELECT COUNT(DISTINCT o.customer_id)
FROM orders o
JOIN customers c ON o.customer_id=c.id
WHERE DATE_PART('day', o.order_date - c.register_date) <= 5

/*
count
3
*/



-- в качестве проверки использовался этот запрос:
-- список заказов, где первая колонка - номер заказа, а вторая - количество дней, которое прошло между датой заказа и датой регистрации пользователя
SELECT o.id order_id, DATE_PART('day', o.order_date - c.register_date) days_after_register
FROM orders o
JOIN customers c ON o.customer_id=c.id

/*
order_id days_after_register
1	0
2	6
3	1
4	5
5	5
6	6
7	6
*/