package com.tp.LeagueApp.models;

import java.util.List;

public class ItemSet {

    Integer itemSetId;
    String itemSetName;
    Integer championId;

    public Integer getItemSetId() {
        return itemSetId;
    }

    public void setItemSetId(Integer itemSetId) {
        this.itemSetId = itemSetId;
    }

    public String getItemSetName() {
        return itemSetName;
    }

    public void setItemSetName(String itemSetName) {
        this.itemSetName = itemSetName;
    }

    public Integer getChampionId() {
        return championId;
    }

    public void setChampionId(Integer championId) {
        this.championId = championId;
    }
}
