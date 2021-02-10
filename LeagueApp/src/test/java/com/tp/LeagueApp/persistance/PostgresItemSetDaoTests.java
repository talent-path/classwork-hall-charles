package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.persistance.postgres.PostgresItemSetDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresItemSetDaoTests {

    @Autowired
    PostgresItemSetDao toTest;

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
    public void createNewItemSetGoldenPath() {
        ItemSet itemSetToAdd = new ItemSet();
        itemSetToAdd.setItemSetName("Testing Item Set");
        itemSetToAdd.setChampionId(1);

        ItemSet returnedItemSet = null;
        try {
            returnedItemSet = toTest.createNewItemSet(itemSetToAdd);
        } catch (NullSetException e) {
            fail();
        }

        assertEquals( 1, returnedItemSet.getItemSetId() );
        assertEquals( "Testing Item Set", returnedItemSet.getItemSetName() );
        assertEquals( 1, returnedItemSet.getChampionId());

        List<ItemSet> allItemSets = toTest.getAllItemSets();

        assertEquals( 1, allItemSets.get(0).getItemSetId() );
        assertEquals( "Testing Item Set", allItemSets.get(0).getItemSetName() );
        assertEquals( 1, allItemSets.get(0).getChampionId());
    }

    @Test
    public void createNewItemSetNullItemSetTest() {
        assertThrows(NullSetException.class, () -> toTest.createNewItemSet(null));
    }

}
