create table Car
(
    CAR_LICENSE       varchar(6)   not null,
    CAR_IMAGE         varchar(250) not null,
    CAR_COPYRIGHT     varchar(80)  null,
    CAR_OWN           int          not null,
    CAR_NAME          varchar(80)  not null,
    CAR_PRICE_PER_DAY int          not null,
    constraint Car_CAR_PLACA_uindex
        unique (CAR_LICENSE),
    constraint CAR_OWN_SERIAL
        foreign key (CAR_OWN) references Owe (OWE_SERIAL)
);

alter table Car
    add primary key (CAR_LICENSE);

