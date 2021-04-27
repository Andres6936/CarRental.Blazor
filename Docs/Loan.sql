create table Loan
(
    LOAN_SERIAL          int auto_increment,
    LOAN_USER            varchar(15)            not null,
    LOAN_DATE_START      date                   not null,
    LOAN_DATE_END        date                   not null,
    LOAN_CAR_LICENSE     varchar(6)             not null,
    LOAN_HB_CANCELED     enum ('TRUE', 'FALSE') not null,
    LOAN_TOTAL_DAYS_USED int                    not null,
    constraint Loan_LOAN_SERIAL_uindex
        unique (LOAN_SERIAL),
    constraint Loan_CAR_LICENSE
        foreign key (LOAN_CAR_LICENSE) references Car (CAR_LICENSE),
    constraint Loan_CLI_USER
        foreign key (LOAN_USER) references User (CLI_USER)
);

alter table Loan
    add primary key (LOAN_SERIAL);

