package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.persistance.postgres.PostgresRuneSetDao;
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
public class PostgresRuneSetDaoTests {

    @Autowired
    PostgresRuneSetDao toTest;

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
    public void createNewRuneSetGoldenPath() {
        RuneSet runeSetToAdd = new RuneSet();
        runeSetToAdd.setRuneSetName("Testing Rune Set");
        runeSetToAdd.setChampionId(1);

        RuneSet returnedRuneSet = null;
        try {
            returnedRuneSet = toTest.createNewRuneSet(runeSetToAdd);
        } catch (NullSetException e) {
            fail();
        }

        assertEquals( 1, returnedRuneSet.getRuneSetId() );
        assertEquals( "Testing Rune Set", returnedRuneSet.getRuneSetName() );
        assertEquals( 1, returnedRuneSet.getChampionId());

        List<RuneSet> allRuneSets = toTest.getAllRuneSets();

        assertEquals( 1, allRuneSets.get(0).getRuneSetId() );
        assertEquals( "Testing Rune Set", allRuneSets.get(0).getRuneSetName() );
        assertEquals( 1, allRuneSets.get(0).getChampionId());
    }

    @Test
    public void createNewRuneSetNullRuneSetTest() {
        assertThrows(NullSetException.class, () -> toTest.createNewRuneSet(null));
    }

    @Test
    public void getAllRuneSetsGoldenPath() {
        template.update("insert into \"RuneSets\" (\"runeSetName\", \"championId\") values (\'Testing Rune Set\', \'1\')");
        template.update("insert into \"RuneSets\" (\"runeSetName\", \"championId\") values (\'Testing2 Rune Set\', \'1\')");

        List<RuneSet> toCheck = toTest.getAllRuneSets();

        assertEquals( 1, toCheck.get(0).getRuneSetId() );
        assertEquals( "Testing Rune Set", toCheck.get(0).getRuneSetName() );
        assertEquals( 1, toCheck.get(0).getChampionId());

        assertEquals( 2, toCheck.get(1).getRuneSetId() );
        assertEquals( "Testing2 Rune Set", toCheck.get(1).getRuneSetName() );
        assertEquals( 1, toCheck.get(1).getChampionId());

    }

    @Test
    public void getRuneSetByNameGoldenPath() {

        template.update("insert into \"RuneSets\" (\"runeSetName\", \"championId\") values (\'Testing Rune Set\', \'1\')");

        RuneSet runeSetToCheck = null;
        try {
            runeSetToCheck = toTest.getRuneSetByName("Testing Rune Set");
        }
        catch(NullNameException e) {
            fail();
        }

        assertEquals( 1, runeSetToCheck.getRuneSetId() );
        assertEquals( "Testing Rune Set", runeSetToCheck.getRuneSetName() );
        assertEquals( 1, runeSetToCheck.getChampionId());

    }

    @Test
    public void getRuneSetByNameNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.getRuneSetByName(null));
    }

    @Test
    public void updateRuneSetGoldenPathTest() {
        template.update("insert into \"RuneSets\" (\"runeSetName\", \"championId\") values (\'Testing Rune Set\', \'1\')");
        template.update("insert into \"Champions\" (\"championName\", \"championDescription\",\"winRate\",\"pickRate\",\"banRate\",\"avgKDA\")\n" +
                "values ('Test','Test Description', '1','1','1','1')");

        RuneSet newUpdateRuneSet = new RuneSet();
        newUpdateRuneSet.setRuneSetId(1);
        newUpdateRuneSet.setRuneSetName("New Update");
        newUpdateRuneSet.setChampionId(2);

        try {
            toTest.updateRuneSet(newUpdateRuneSet);
        } catch (NullSetException | NullIdException e) {
            fail();
        }

        RuneSet toCheck = null;
        try {
            toCheck = toTest.getRuneSetByName("New Update");
        } catch (NullNameException e) {
            fail();
        }

        assertEquals( 1, toCheck.getRuneSetId() );
        assertEquals( "New Update", toCheck.getRuneSetName() );
        assertEquals( 2, toCheck.getChampionId());

    }

    @Test
    public void updateRuneSetNullRuneSetTest() {
        assertThrows(NullSetException.class, () -> toTest.updateRuneSet(null));
    }

    @Test
    public void updateRuneSetNullIdTest() {
        RuneSet toCheck = new RuneSet();
        toCheck.setRuneSetId(null);
        toCheck.setRuneSetName("Test");
        toCheck.setChampionId(1);

        assertThrows(NullIdException.class, () -> toTest.updateRuneSet(toCheck));
    }

    @Test
    public void deleteRuneSetGoldenPath() {
        template.update("insert into \"RuneSets\" (\"runeSetName\", \"championId\") values (\'Testing Rune Set\', \'1\')");

        try {
            toTest.deleteRuneSet("Testing Rune Set");
        } catch (NullNameException e) {
            fail();
        }

        List<RuneSet> toCheck = toTest.getAllRuneSets();

        assertEquals(0, toCheck.size());
    }

    @Test
    public void deleteRuneSetNullNameTest() {
        assertThrows(NullNameException.class, () -> toTest.deleteRuneSet(null));
    }
}
