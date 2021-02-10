package com.tp.LeagueApp.persistance;

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

import static org.junit.jupiter.api.Assertions.assertEquals;

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
    public void createNewItemSetGoldenPath() {
        RuneSet runeSetToAdd = new RuneSet();
        runeSetToAdd.setRuneSetName("Testing Rune Set");
        runeSetToAdd.setChampionId(1);

        RuneSet returnedRuneSet = toTest.createNewRuneSet(runeSetToAdd);

        assertEquals( 1, returnedRuneSet.getRuneSetId() );
        assertEquals( "Testing Rune Set", returnedRuneSet.getRuneSetName() );
        assertEquals( 1, returnedRuneSet.getChampionId());

        List<RuneSet> allRuneSets = toTest.getAllRuneSets();

        assertEquals( 1, allRuneSets.get(0).getRuneSetId() );
        assertEquals( "Testing Rune Set", allRuneSets.get(0).getRuneSetName() );
        assertEquals( 1, allRuneSets.get(0).getChampionId());

    }
}
