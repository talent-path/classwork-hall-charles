package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Rune;
import com.tp.LeagueApp.models.SummonerSpell;
import com.tp.LeagueApp.persistance.postgres.PostgresSummonerSpellDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresSummonerSpellDaoTests {

    @Autowired
    PostgresSummonerSpellDao toTest;

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
        template.update("insert into \"SummonerSpells\" (\"summSpellName\", \"summSpellDescription\") values ('Test', 'Test Description')");

        SummonerSpell toCheck = null;
        try {
            toCheck = toTest.getSummonerSpellByName("Test");
        }
        catch(NullNameException e) {
            fail();
        }

        assertEquals(1, toCheck.getSummonerSpellId());
        assertEquals("Test", toCheck.getSummonerSpellName());
        assertEquals("Test Description", toCheck.getSummonerSpellDescription());

    }

    @Test
    public void getRuneByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getSummonerSpellByName(null));
    }

}
