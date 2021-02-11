package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.InvalidItemException;
import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.persistance.postgres.PostgresItemSetDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.math.BigDecimal;
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
        } catch (NullSetException | InvalidItemException e) {
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

    @Test
    public void getAllItemSetsGoldenPath() {
        template.update("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (\'Testing Item Set\', \'1\')");
        template.update("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (\'Testing2 Item Set\', \'1\')");

        List<ItemSet> toCheck = toTest.getAllItemSets();

        assertEquals( 1, toCheck.get(0).getItemSetId() );
        assertEquals( "Testing Item Set", toCheck.get(0).getItemSetName() );
        assertEquals( 1, toCheck.get(0).getChampionId());

        assertEquals( 2, toCheck.get(1).getItemSetId() );
        assertEquals( "Testing2 Item Set", toCheck.get(1).getItemSetName() );
        assertEquals( 1, toCheck.get(1).getChampionId());

    }

    @Test
    public void getItemSetByNameGoldenPath() {

        template.update("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (\'Testing Item Set\', \'1\')");

        ItemSet itemSetToCheck = null;
        try {
            itemSetToCheck = toTest.getItemSetByName("Testing Item Set");
        }
        catch(NullNameException e) {
            fail();
        }

        assertEquals( 1, itemSetToCheck.getItemSetId() );
        assertEquals( "Testing Item Set", itemSetToCheck.getItemSetName() );
        assertEquals( 1, itemSetToCheck.getChampionId());

    }

    @Test
    public void getItemSetByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getItemSetByName(null));
    }

    @Test
    public void getItemSetByIdGoldenPath() {

        template.update("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (\'Testing Item Set\', \'1\')");

        ItemSet itemSetToCheck = null;
        try {
            itemSetToCheck = toTest.getItemSetById(1);
        }
        catch(NullIdException e) {
            fail();
        }

        assertEquals( 1, itemSetToCheck.getItemSetId() );
        assertEquals( "Testing Item Set", itemSetToCheck.getItemSetName() );
        assertEquals( 1, itemSetToCheck.getChampionId());

    }

    @Test
    public void getItemSetByIdNullIdTest() {
        assertThrows(NullIdException.class, () -> toTest.getItemSetById(null));
    }

    @Test
    public void updateItemSetGoldenPathTest() {
        template.update("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (\'Testing Item Set\', \'1\')");
        template.update("insert into \"Champions\" (\"championName\", \"championDescription\",\"winRate\",\"pickRate\",\"banRate\",\"avgKDA\")\n" +
                "values ('Test','Test Description', '1','1','1','1')");

        ItemSet newUpdateItemSet = new ItemSet();
        newUpdateItemSet.setItemSetId(1);
        newUpdateItemSet.setItemSetName("New Update");
        newUpdateItemSet.setChampionId(2);

        try {
            toTest.updateItemSet(newUpdateItemSet);
        } catch (NullSetException | NullIdException e) {
            fail();
        }

        ItemSet toCheck = null;
        try {
            toCheck = toTest.getItemSetByName("New Update");
        } catch (NullNameException e) {
            fail();
        }

        assertEquals( 1, toCheck.getItemSetId() );
        assertEquals( "New Update", toCheck.getItemSetName() );
        assertEquals( 2, toCheck.getChampionId());

    }

    @Test
    public void updateItemSetNullItemSetTest() {
        assertThrows(NullSetException.class, () -> toTest.updateItemSet(null));
    }

    @Test
    public void updateItemSetNullIdTest() {
        ItemSet toCheck = new ItemSet();
        toCheck.setItemSetId(null);
        toCheck.setItemSetName("Test");
        toCheck.setChampionId(1);

        assertThrows(NullIdException.class, () -> toTest.updateItemSet(toCheck));
    }

    @Test
    public void deleteItemSetGoldenPath() {
        template.update("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (\'Testing Item Set\', \'1\')");

        try {
            toTest.deleteItemSet("Testing Item Set");
        } catch (NullNameException e) {
            fail();
        }

        List<ItemSet> toCheck = toTest.getAllItemSets();

        assertEquals(0, toCheck.size());
    }

    @Test
    public void deleteItemSetNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.deleteItemSet(null));
    }

}
