
create table course
(
    id serial primary key,
    name varchar(50) unique not null,
    duration_course date,
    price money,
    create_at date,
    update_at date,
    is_dalated bool default false
);

create table groups
(
    id serial primary key,
    name varchar(50) unique not null,
    course_id int references course(id) on delete set null,
    max_students int,
    min_students int,
    create_at date,
    update_at date,
    is_dalated bool default false
);

create table student
(
    id serial primary key,
    first_name varchar not null,
    last_name varchar not null,
    phone_number varchar(13) unique not null,
    address varchar(100) not null,
    email varchar(100) unique not null,
    create_at date,
    update_at date,
    is_dalated bool default false
);

create table student_groups
(
    id serial primary key,
    student_id int,
    group_id int,
    foreign key(student_id) references student(id) on delete set null,
    foreign key(group_id) references groups(id) on delete set null
);

create type positions as enum('C# Mentor', 'C++ Mentor', 'HTML Mentor')

create table mentors
(
    id serial primary key,
    first_name varchar not null,
    last_name varchar not null,
    position positions,
    phone_number varchar(13) unique not null,
    address varchar(100) not null,
    email varchar(100) unique not null,
    create_at date,
    update_at date,
    is_dalated bool default false
);

create table mentor_groups
(
    id serial primary key,
    mentors_id int references mentors(id) on delete set null,
    group_id int references groups(id) on delete set null
);