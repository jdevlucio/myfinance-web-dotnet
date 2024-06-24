create database myfinance
go

use myfinance
go

create table PlanoConta(
 id int not null identity (1,1),
 descricao varchar(50) not null,
 tipo char(1) not null,
 primary key(id)
);
go

create table Transacao(
 id int not null identity (1,1),
 historico varchar(50)  null,
 data datetime not null,
 valor decimal (9,2) not null,
 planocontaid int not null,
 primary key(id),
 foreign key ( planocontaid ) references PlanoConta(id)
);
go


insert into PlanoConta(descricao, tipo) values ('Combustivel', 'D');
insert into PlanoConta(descricao, tipo) values ('Alimentacao', 'D');
insert into PlanoConta(descricao, tipo) values ('Saude', 'D');
insert into PlanoConta(descricao, tipo) values ('Educacao', 'D');
insert into PlanoConta(descricao, tipo) values ('Salario', 'R');
insert into PlanoConta(descricao, tipo) values ('Juros', 'R');
select * from PlanoConta;

set dateformat dmy;
insert into Transacao(historico, data, valor, planocontaid) values ('Jantar','20-06-2024 20:00' , 359,1);
insert into Transacao(historico, data, valor, planocontaid) values ('Almoco','20-06-2024 12:00' , 60,2);
select * from Transacao;