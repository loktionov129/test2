CREATE TABLE products (
  id bigserial PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  description VARCHAR(255) NOT NULL
);

CREATE TABLE customers (
  id BIGSERIAL PRIMARY KEY,
  first_name VARCHAR(30) NOT NULL,
  last_name VARCHAR(30) NOT NULL,
  register_date TIMESTAMP DEFAULT NOW()
);

CREATE TABLE orders (
  id bigserial PRIMARY KEY,
  product_id BIGSERIAL REFERENCES products (id),
  customer_id BIGSERIAL REFERENCES customers (id),
  quantity INT NOT NULL,
  order_date TIMESTAMP DEFAULT NOW()
);

INSERT INTO products (name, description) VALUES
('Apple iPhone 12 Pro Max', 'Удобный и понятный; Мощный и умный; Надёжный и актуальный.'),
('Apple MacBook Pro 16"', 'Самый мощный ноутбук, созданный для тех, кто меняет мир и раздвигает границы.'),
('Apple Watch Series 6, 44 мм', 'Мощное устройство для здорового образа жизни.');

INSERT INTO customers (first_name, last_name, register_date) VALUES
('Иван', 'Иванов', '2011-01-21'),
('Петр', 'Петров', '2012-02-22'),
('Александр', 'Александров', '2013-03-23'),
('Андрей', 'Андреев', '2014-04-24'),
('Сергей', 'Сергеев', '2015-05-25'),
('Антон', 'Антонов', '2016-06-26');

INSERT INTO orders (product_id, customer_id, quantity, order_date) VALUES
-- iPhone, Иванов Иван, 1шт, в день регистрации (должен учитываться в отчёте)
(1, 1, 1, '2011-01-21'),

-- Apple Watch, Петров Петр, 2шт, через 6 дней после регистрации
(3, 2, 2, '2012-02-28'),

-- MacBook, Александров Александр, 1шт, через 1 день после регистрации (должен учитываться в отчёте)
(2, 3, 1, '2013-03-24'),

-- Андреев Андрей зарегистрировался, но не совершал покупок.

-- MacBook, Сергеев Сергей, 1шт, через 5 дней после регистрации  (должен учитываться в отчёте)
(2, 5, 1, '2015-05-30'),
-- iPhone, Сергеев Сергей, 2шт, через 5 дней после регистрации
(1, 5, 2, '2015-05-30'),
-- Apple Watch, Сергеев Сергей, 1шт, через 6 дней после регистрации
(3, 5, 1, '2015-05-31'),

-- MacBook, Антонов Антон, 1шт, через 6 дней после регистрации
(2, 6, 1, '2016-07-01');

