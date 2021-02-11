package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.models.Rune;
import com.tp.LeagueApp.persistance.postgres.PostgresRuneDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
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

    @BeforeEach
    public void setup(){

        //need to clear all tables and reset all sequences

        template.update("truncate \"ItemSetItems\", \"RuneSetRunes\", \"SummonerSpellSetSummonerSpells\", \"ItemSets\", \"Items\",\n" +
                "\"RuneSets\", \"Runes\", \"SummonerSpellSets\", \"SummonerSpells\", \"Champions\" RESTART IDENTITY;");

        template.update("insert into \"Champions\" (\"championName\", \"championDescription\",\"winRate\",\"pickRate\",\"banRate\",\"avgKDA\")\n" +
                "values ('Test','Test Description', '1','1','1','1')");
    }

    @Test
    public void getRuneByNameGoldenPath() {
        template.update("insert into \"Runes\" (\"runeName\", \"runeDescription\") values ('Test', 'Test Description')");

        Rune toCheck = null;
        try {
            toCheck = toTest.getRuneByName("Test");
        }
        catch(NullNameException e) {
            fail();
        }

        assertEquals(1, toCheck.getRuneId());
        assertEquals("Test", toCheck.getRuneName());
        assertEquals("Test Description", toCheck.getRuneDescription());

    }

    @Test
    public void getRuneByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getRuneByName(null));
    }
}
