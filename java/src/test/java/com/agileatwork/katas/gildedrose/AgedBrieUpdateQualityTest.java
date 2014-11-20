package com.agileatwork.katas.gildedrose;

import org.junit.Test;

import java.util.Arrays;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

public class AgedBrieUpdateQualityTest
{
    @Test
    public void shouldIncreaseQualityWhenGetsOlder()
    {
        Item agedBrie = new Item("Aged Brie", 1, 1);

        GildedRose.updateQuality(Arrays.asList(agedBrie));

        assertThat(agedBrie.getQuality(), is(2));
    }

    @Test
    public void shouldNeverIncreaseQualityOverLimit()
    {
        Item agedBrie = new Item("Aged Brie", 1, 50);

        GildedRose.updateQuality(Arrays.asList(agedBrie));

        assertThat(agedBrie.getQuality(), is(50));
    }
}
