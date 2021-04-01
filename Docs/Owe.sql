create table Owe
(
    OWE_SERIAL     int         not null,
    OWE_FIRST_NAME varchar(80) not null,
    OWE_LAST_NAME  varchar(80) null,
    constraint Owe_OWE_SERIAL_uindex
        unique (OWE_SERIAL)
);

alter table Owe
    add primary key (OWE_SERIAL);

