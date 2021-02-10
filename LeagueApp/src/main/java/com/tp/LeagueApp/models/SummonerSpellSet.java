package com.tp.LeagueApp.models;

public class SummonerSpellSet {
    Integer summonerSpellSetId;
    String summonerSpellSetName;
    Integer championId;

    public Integer getSummonerSpellSetId() {
        return summonerSpellSetId;
    }

    public void setSummonerSpellSetId(Integer summonerSpellSetId) {
        this.summonerSpellSetId = summonerSpellSetId;
    }

    public String getSummonerSpellSetName() {
        return summonerSpellSetName;
    }

    public void setSummonerSpellSetName(String summonerSpellSetName) {
        this.summonerSpellSetName = summonerSpellSetName;
    }

    public Integer getChampionId() {
        return championId;
    }

    public void setChampionId(Integer championId) {
        this.championId = championId;
    }
}
