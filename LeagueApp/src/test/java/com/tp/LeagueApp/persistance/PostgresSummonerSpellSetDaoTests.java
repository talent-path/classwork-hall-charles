package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.*;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.models.SummonerSpellSet;
import com.tp.LeagueApp.persistance.postgres.PostgresSummonerSpellSetDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.test.context.ActiveProfiles;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class PostgresSummonerSpellSetDaoTests {

    @Autowired
    PostgresSummonerSpellSetDao toTest;

    @Autowired
    JdbcTemplate template;

    @BeforeEach
    public void setup(){

        //need to clear all tables and reset all sequences

        template.update("truncate \"ItemSetItems\", \"RuneSetRunes\", \"SummonerSpellSetSummonerSpells\", \"ItemSets\", \"Items\",\n" +
                "\"RuneSets\", \"Runes\", \"SummonerSpellSets\", \"SummonerSpells\", \"Champions\" RESTART IDENTITY;");

        template.update("insert into \"Champions\" (\"championName\", \"championDescription\",\"winRate\",\"pickRate\",\"banRate\",\"avgKDA\")\n" +
                "values ('Test','Test Description', '1','1','1','1')");

        template.update("insert into \"SummonerSpells\" (\"summSpellName\", \"summSpellDescription\") values ('Test', 'Test Description')");

    }

    @Test
    public void createNewSummonerSpellSetGoldenPath() {
        SummonerSpellSet summSetToAdd = new SummonerSpellSet();
        summSetToAdd.setSummonerSpellSetName("Testing Summ Set");
        summSetToAdd.setChampionId(1);
        List<Integer> testList = new ArrayList<>();
        testList.add(1);
        summSetToAdd.setSummonerSpellIdList(testList);

        SummonerSpellSet returnedSummonerSpellSet = null;
        try {
            returnedSummonerSpellSet = toTest.createNewSummonerSpellSet(summSetToAdd);
        } catch (NullSetException | EmptySummonerSpellListException | InvalidSummonerSpellException e) {
            fail();
        }

        assertEquals( 1, returnedSummonerSpellSet.getSummonerSpellSetId() );
        assertEquals( "Testing Summ Set", returnedSummonerSpellSet.getSummonerSpellSetName() );
        assertEquals( 1, returnedSummonerSpellSet.getChampionId());

        List<SummonerSpellSet> allItemSets = toTest.getAllSummonerSpellSets();

        assertEquals( 1, allItemSets.get(0).getSummonerSpellSetId() );
        assertEquals( "Testing Summ Set", allItemSets.get(0).getSummonerSpellSetName() );
        assertEquals( 1, allItemSets.get(0).getChampionId());
    }

    @Test
    public void createNewSummonerSpellSetNullSummonerSpellSetTest() {
        assertThrows(NullSetException.class, () -> toTest.createNewSummonerSpellSet(null));
    }

    @Test
    public void createNewSummonerSpellSetEmptySummonerSpellIdListTest() {
        SummonerSpellSet testSummSpellSet = new SummonerSpellSet();
        testSummSpellSet.setSummonerSpellSetId(1);
        testSummSpellSet.setSummonerSpellSetName("Test");
        testSummSpellSet.setChampionId(1);
        List<Integer> testList = new ArrayList<>();
        testSummSpellSet.setSummonerSpellIdList(testList);

        assertThrows(EmptySummonerSpellListException.class, () -> toTest.createNewSummonerSpellSet(testSummSpellSet));
    }

    @Test
    public void createNewSummonerSpellSetInvalidSummonerSpellTest() {
        SummonerSpellSet testSummSpellSet = new SummonerSpellSet();
        testSummSpellSet.setSummonerSpellSetId(1);
        testSummSpellSet.setSummonerSpellSetName("Test");
        testSummSpellSet.setChampionId(1);
        List<Integer> testList = new ArrayList<>();
        testList.add(100000);
        testSummSpellSet.setSummonerSpellIdList(testList);

        assertThrows(InvalidSummonerSpellException.class, () -> toTest.createNewSummonerSpellSet(testSummSpellSet));
    }

    @Test
    public void getAllSummonerSpellSetsGoldenPath() {
        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing Summoner Spell Set\', \'1\')");
        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing2 Summoner Spell Set\', \'1\')");

        List<SummonerSpellSet> toCheck = toTest.getAllSummonerSpellSets();

        assertEquals( 1, toCheck.get(0).getSummonerSpellSetId() );
        assertEquals( "Testing Summoner Spell Set", toCheck.get(0).getSummonerSpellSetName() );
        assertEquals( 1, toCheck.get(0).getChampionId());

        assertEquals( 2, toCheck.get(1).getSummonerSpellSetId() );
        assertEquals( "Testing2 Summoner Spell Set", toCheck.get(1).getSummonerSpellSetName() );
        assertEquals( 1, toCheck.get(1).getChampionId());

    }

    @Test
    public void getSummonerSpellSetByNameGoldenPath() {

        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing Summoner Spell Set\', \'1\')");

        SummonerSpellSet summSpellSetToCheck = null;
        try {
            summSpellSetToCheck = toTest.getSummonerSpellSetByName("Testing Summoner Spell Set");
        }
        catch(NullNameException e) {
            fail();
        }

        assertEquals( 1, summSpellSetToCheck.getSummonerSpellSetId() );
        assertEquals( "Testing Summoner Spell Set", summSpellSetToCheck.getSummonerSpellSetName() );
        assertEquals( 1, summSpellSetToCheck.getChampionId());

    }

    @Test
    public void getSummonerSpellSetByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getSummonerSpellSetByName(null));
    }

    @Test
    public void getSummonerSpellSetByIdGoldenPath() {

        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing Summoner Spell Set\', \'1\')");

        SummonerSpellSet summSpellSetToCheck = null;
        try {
            summSpellSetToCheck = toTest.getSummonerSpellSetById(1);
        }
        catch(NullIdException | InvalidSetException e) {
            fail();
        }

        assertEquals( 1, summSpellSetToCheck.getSummonerSpellSetId() );
        assertEquals( "Testing Summoner Spell Set", summSpellSetToCheck.getSummonerSpellSetName() );
        assertEquals( 1, summSpellSetToCheck.getChampionId());

    }

    @Test
    public void getSummonerSpellSetByIdNullIdTest() {
        assertThrows(NullIdException.class, () -> toTest.getSummonerSpellSetById(null));
    }

    @Test
    public void getSummonerSpellSetByIdInvalidSetTest() {
        assertThrows(InvalidSetException.class, () -> toTest.getSummonerSpellSetById(100000));
    }

    @Test
    public void updateRuneSetGoldenPathTest() {
        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing Summoner Spell Set\', \'1\')");
        template.update("insert into \"Champions\" (\"championName\", \"championDescription\",\"winRate\",\"pickRate\",\"banRate\",\"avgKDA\")\n" +
                "values ('Test','Test Description', '1','1','1','1')");

        SummonerSpellSet newUpdateSummonerSpellSet = new SummonerSpellSet();
        newUpdateSummonerSpellSet.setSummonerSpellSetId(1);
        newUpdateSummonerSpellSet.setSummonerSpellSetName("New Update");
        newUpdateSummonerSpellSet.setChampionId(2);

        try {
            toTest.updateSummonerSpellSet(newUpdateSummonerSpellSet);
        } catch (NullSetException | NullIdException | InvalidSetException e) {
            fail();
        }

        SummonerSpellSet toCheck = null;
        try {
            toCheck = toTest.getSummonerSpellSetByName("New Update");
        } catch (NullNameException e) {
            fail();
        }

        assertEquals( 1, toCheck.getSummonerSpellSetId() );
        assertEquals( "New Update", toCheck.getSummonerSpellSetName() );
        assertEquals( 2, toCheck.getChampionId());

    }

    @Test
    public void updateSummonerSpellSetNullRuneSetTest() {
        assertThrows(NullSetException.class, () -> toTest.updateSummonerSpellSet(null));
    }

    @Test
    public void updateSummonerSpellSetInvalidSummonerSpellSetTest() {
        SummonerSpellSet newUpdateSummSpellSet = new SummonerSpellSet();
        newUpdateSummSpellSet.setSummonerSpellSetId(100000);
        newUpdateSummSpellSet.setSummonerSpellSetName("New Update");
        newUpdateSummSpellSet.setChampionId(2);

        assertThrows(InvalidSetException.class, () -> toTest.updateSummonerSpellSet(newUpdateSummSpellSet));
    }

    @Test
    public void updateSummonerSpellSetNullIdTest() {
        SummonerSpellSet toCheck = new SummonerSpellSet();
        toCheck.setSummonerSpellSetId(null);
        toCheck.setSummonerSpellSetName("Test");
        toCheck.setChampionId(1);

        assertThrows(NullIdException.class, () -> toTest.updateSummonerSpellSet(toCheck));
    }

    @Test
    public void deleteSummonerSpellSetGoldenPath() {
        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing Summoner Spell Set\', \'1\')");

        try {
            toTest.deleteSummonerSpellSet("Testing Summoner Spell Set");
        } catch (NullNameException e) {
            fail();
        }

        List<SummonerSpellSet> toCheck = toTest.getAllSummonerSpellSets();

        assertEquals(0, toCheck.size());
    }

    @Test
    public void deleteSummonerSpellSetNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.deleteSummonerSpellSet(null));
    }

    @Test
    public void deleteSummonerSpellSetByIdGoldenPath() {
        template.update("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (\'Testing Summoner Spell Set\', \'1\')");

        try {
            toTest.deleteSummonerSpellSetById(1);
        } catch (NullIdException | InvalidSetException e) {
            fail();
        }

        List<SummonerSpellSet> toCheck = toTest.getAllSummonerSpellSets();

        assertEquals(0, toCheck.size());
    }

    @Test
    public void deleteSummonerSpellSetByIdNullIdTest() {
        assertThrows(NullIdException.class, () -> toTest.deleteSummonerSpellSetById(null));
    }

    @Test
    public void deleteSummonerSPellSetByIdInvalidSetTest() {
        assertThrows(InvalidSetException.class, () -> toTest.deleteSummonerSpellSetById(100000));
    }
}
