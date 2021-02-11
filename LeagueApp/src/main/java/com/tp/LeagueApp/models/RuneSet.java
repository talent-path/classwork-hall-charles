package com.tp.LeagueApp.models;

import java.util.List;

public class RuneSet {

    Integer runeSetId;
    String runeSetName;
    Integer championId;
    List<Rune> runeList;

    public Integer getRuneSetId() {
        return runeSetId;
    }

    public void setRuneSetId(Integer runeSetId) {
        this.runeSetId = runeSetId;
    }

    public String getRuneSetName() {
        return runeSetName;
    }

    public void setRuneSetName(String runeSetName) {
        this.runeSetName = runeSetName;
    }

    public Integer getChampionId() {
        return championId;
    }

    public void setChampionId(Integer championId) {
        this.championId = championId;
    }

    public List<Rune> getRuneList() {
        return runeList;
    }

    public void setRuneList(List<Rune> runeList) {
        this.runeList = runeList;
    }
}
