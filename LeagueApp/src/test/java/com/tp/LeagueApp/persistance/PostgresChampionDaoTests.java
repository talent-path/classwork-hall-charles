package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.persistance.postgres.PostgresChampionDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.math.BigDecimal;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresChampionDaoTests {

    @Autowired
    PostgresChampionDao toTest;

    @Autowired
    JdbcTemplate template;

    @BeforeEach
    public void setup(){

        //need to clear all tables and reset all sequences

        template.update("truncate \"ItemSetItems\", \"RuneSetRunes\", \"SummonerSpellSetSummonerSpells\", \"ItemSets\", \"Items\",\n" +
                "\"RuneSets\", \"Runes\", \"SummonerSpellSets\", \"SummonerSpells\", \"Champions\" RESTART IDENTITY;");

        template.update("insert into \"Champions\" (\"championName\", \"championDescription\",\"winRate\",\"pickRate\",\"banRate\",\"avgKDA\")\n" +
                "values ('Test','Test Description', '1','1','1','1')");
    }

    @Test
    public void getChampionByNameGoldenPath() {

        Champion toCheck = null;
        try {
            toCheck = toTest.getChampionByName("Test");
        } catch (NullNameException e) {
            fail();
        }

        BigDecimal one = BigDecimal.valueOf(1);

        assertEquals(1, toCheck.getChampionId());
        assertEquals("Test", toCheck.getChampionName());
        assertEquals("Test Description", toCheck.getChampionDescription());
        assertEquals(one, toCheck.getWinRate());
        assertEquals(one, toCheck.getPickRate());
        assertEquals(one, toCheck.getBanRate());
        assertEquals(one, toCheck.getAvgKDA());

    }

    @Test
    public void getChampionByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getChampionByName(null));
    }

}
