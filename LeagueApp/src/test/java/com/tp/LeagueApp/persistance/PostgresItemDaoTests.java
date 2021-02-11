package com.tp.LeagueApp.persistance;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.persistance.postgres.PostgresItemDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresItemDaoTests {

    @Autowired
    PostgresItemDao toTest;

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
    public void getItemByNameGoldenPath() {
        template.update("insert into \"Items\" (\"itemName\", \"itemDescription\", \"itemCost\") values ('Test', 'Test Description', '1000')");

        Item toCheck = null;
        try {
            toCheck = toTest.getItemByName("Test");
        }
        catch(NullNameException e) {
            fail();
        }

        assertEquals(1, toCheck.getItemId());
        assertEquals("Test", toCheck.getItemName());
        assertEquals("Test Description", toCheck.getItemDescription());
        assertEquals(1000, toCheck.getItemCost());

    }

    @Test
    public void getItemByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getItemByName(null));
    }
}
