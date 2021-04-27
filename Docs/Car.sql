create table Car
(
    CAR_LICENSE       varchar(6)                                            not null,
    CAR_IMAGE         varchar(250)                                          not null,
    CAR_COPYRIGHT     varchar(80)                                           null,
    CAR_NAME          varchar(80)                                           not null,
    CAR_PRICE_PER_DAY int                                                   not null,
    CAR_BAGS          smallint                                              null,
    CAR_DOORS         smallint                                              null,
    CAR_PEOPLE        smallint                                              null,
    CAR_TRANSMISSION  enum ('Manual', 'Automatic')                          null,
    CAR_AIR           enum ('Air-conditioning', 'Without Air-conditioning') null,
    CAR_IS_OWN        enum ('YES', 'NO')                                    not null,
    CAR_USER_USERNAME varchar(15)                                           not null,
    constraint Car_CAR_PLACA_uindex
        unique (CAR_LICENSE),
    constraint Car_User_CLI_USER_fk
        foreign key (CAR_USER_USERNAME) references User (CLI_USER)
);

alter table Car
    add primary key (CAR_LICENSE);

