package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.models.SummonerSpellSet;
import com.tp.LeagueApp.persistance.postgres.PostgresSummonerSpellSetDao;
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
    }

    @Test
    public void createNewSummonerSpellSetGoldenPath() {
        SummonerSpellSet summSetToAdd = new SummonerSpellSet();
        summSetToAdd.setSummonerSpellSetName("Testing Summ Set");
        summSetToAdd.setChampionId(1);

        SummonerSpellSet returnedSummonerSpellSet = toTest.createNewSummonerSpellSet(summSetToAdd);

        assertEquals( 1, returnedSummonerSpellSet.getSummonerSpellSetId() );
        assertEquals( "Testing Summ Set", returnedSummonerSpellSet.getSummonerSpellSetName() );
        assertEquals( 1, returnedSummonerSpellSet.getChampionId());

        List<SummonerSpellSet> allItemSets = toTest.getAllSummonerSpellSets();

        assertEquals( 1, allItemSets.get(0).getSummonerSpellSetId() );
        assertEquals( "Testing Summ Set", allItemSets.get(0).getSummonerSpellSetName() );
        assertEquals( 1, allItemSets.get(0).getChampionId());
    }
}
