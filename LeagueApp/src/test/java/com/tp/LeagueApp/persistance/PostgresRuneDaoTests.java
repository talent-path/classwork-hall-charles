package com.tp.LeagueApp.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresRuneDaoTests {

    @Autowired
    PostgresRuneDao toTest;

    @Autowired
    JdbcTemplate template;
}
