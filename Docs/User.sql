create table User
(
    CLI_USER               varchar(15) not null,
    CLI_PASSWORD           varchar(80) not null,
    CLI_EMAIL              varchar(80) not null,
    CLI_FIRST_NAME         varchar(80) not null,
    CLI_LAST_NAME          varchar(80) null,
    CLI_CREDIT_CARD_NUMBER varchar(22) null,
    CLI_CREDIT_CARD_CVV    int         null,
    CLI_COUNTRY            varchar(80) null,
    CLI_PHONE              varchar(12) null,
    constraint Cliente_CLI_USER_uindex
        unique (CLI_USER)
);

alter table User
    add primary key (CLI_USER);

