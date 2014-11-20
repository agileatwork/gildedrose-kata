package com.agileatwork.katas.gildedrose;

import org.junit.Test;

import java.util.Arrays;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

public class SulfurasUpdateQualityTest
{
    @Test
    public void shouldNeverBeSold()
    {
        Item sulfuras = new Item("Sulfuras, Hand of Ragnaros", 0, 80);

        GildedRose.updateQuality(Arrays.asList(sulfuras));

        assertThat(sulfuras.getSellIn(), is(0));
    }

    @Test
    public void shouldNeverDecreaseQuality()
    {
        Item sulfuras = new Item("Sulfuras, Hand of Ragnaros", 0, 80);

        GildedRose.updateQuality(Arrays.asList(sulfuras));

        assertThat(sulfuras.getQuality(), is(80));
    }
}