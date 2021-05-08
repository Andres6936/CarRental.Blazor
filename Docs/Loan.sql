create table Loan
(
    LOAN_SERIAL           int auto_increment,
    LOAN_DATE_START       date                   not null,
    LOAN_DATE_END         date                   not null,
    LOAN_CAR_LICENSE      varchar(6)             not null,
    LOAN_HB_CANCELED      enum ('TRUE', 'FALSE') not null,
    LOAN_TOTAL_DAYS_USED  int                    not null,
    CC_CREDIT_CARD_NUMBER varchar(22)            not null,
    constraint Loan_LOAN_SERIAL_uindex
        unique (LOAN_SERIAL),
    constraint Loan_CAR_LICENSE
        foreign key (LOAN_CAR_LICENSE) references Car (CAR_LICENSE),
    constraint Loan_CREDIT_CARD_NUMBER_FK
        foreign key (CC_CREDIT_CARD_NUMBER) references CreditCard (CC_CREDIT_CARD_NUMBER)
);

alter table Loan
    add primary key (LOAN_SERIAL);

