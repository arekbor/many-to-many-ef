sql scripts for create tables:

create table user_table (
id serial primary key,
username varchar(100) null,
user_id varchar(100) unique not null
);

create table claim_table (
id serial primary key,
claim_name varchar(100) null,
claim_id varchar(100) unique not null
);

create table user_claims_table (
id serial primary key,
user_claims_claim_id varchar(100) references claim_table (claim_id),
user_table_user_id varchar(100) references user_table (user_id)
);

sql script for mocks:

INSERT INTO claim_table (claim_name, claim_id) VALUES
('ReadAccess', 'RA001'),
('WriteAccess', 'WA002'),
('AdminAccess', 'AA003');

INSERT INTO user_table (username, user_id) VALUES
('JohnDoe', 'JD123'),
('AliceSmith', 'AS456'),
('MarkEldon', 'EB106'),
('JohnCheese', 'XX006'),
('BobJohnson', 'BJ789');

INSERT INTO user_claims_table (user_claims_claim_id, user_table_user_id) VALUES
('RA001', 'XX006'),
('WA002', 'XX006'),
('AA003', 'XX006');
