package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.persistance.postgres.PostgresChampionDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresChampionDaoTests {

    @Autowired
    PostgresChampionDao toTest;

    @Autowired
    JdbcTemplate template;

}
