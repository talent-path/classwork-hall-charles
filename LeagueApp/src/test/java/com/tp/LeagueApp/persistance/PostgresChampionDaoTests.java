package com.tp.LeagueApp.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresChampionDaoTests {

    @Autowired
    PostgresChampionDao toTest;

    @Autowired
    JdbcTemplate template;

}
