package com.agileatwork.katas.gildedrose;

import org.junit.Test;

import java.util.Arrays;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

public class AnyItemUpdateQualityTest
{
    @Test
    public void shouldDegradeQualityOnUpdate()
    {
        Item item = new Item("ANY_ITEM", 1, 20);

        GildedRose.updateQuality(Arrays.asList(item));

        assertThat(item.quality, is(19));
    }

    @Test
    public void shouldDegradeDoubleWhenSellinDatePass()
    {
        Item item = new Item("ANY_ITEM", 0, 20);

        GildedRose.updateQuality(Arrays.asList(item));

        assertThat(item.quality, is(18));
    }

    @Test
    public void shouldNeverGetNegativeValuesForQuality()
    {
        Item item = new Item("ANY_ITEM", 0, 0);

        GildedRose.updateQuality(Arrays.asList(item));

        assertThat(item.quality, is(0));
    }

}
