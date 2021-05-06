create table User
(
    CLI_USER       varchar(15)                                                                 not null,
    CLI_PASSWORD   varchar(80)                                                                 not null,
    CLI_EMAIL      varchar(80)                                                                 not null,
    CLI_FIRST_NAME varchar(80)                                                                 not null,
    CLI_LAST_NAME  varchar(80)                                                                 null,
    CLI_COUNTRY    varchar(80)                                                                 null,
    CLI_PHONE      varchar(12)                                                                 null,
    CLI_ROLE       enum ('Administrator', 'Owe', 'User') default 'User'                        not null,
    CLI_ICON       varchar(255)                          default 'img/png/avatars/unknown.png' not null,
    constraint Cliente_CLI_USER_uindex
        unique (CLI_USER)
);

alter table User
    add primary key (CLI_USER);

