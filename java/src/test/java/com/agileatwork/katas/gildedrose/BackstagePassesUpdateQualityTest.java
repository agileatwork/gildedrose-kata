package es.alfredocasado.katas.gildedrose;

import com.agileatwork.katas.gildedrose.GildedRose;
import com.agileatwork.katas.gildedrose.Item;
import org.junit.Test;

import java.util.Arrays;

import static org.hamcrest.core.Is.is;
import static org.junit.Assert.assertThat;

public class BackstagePassesUpdateQualityTest
{
    @Test
    public void shouldIncreaseQualityAsTheSellinDateDecrease()
    {
        Item backstagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20);

        GildedRose.updateQuality(Arrays.asList(backstagePass));

        assertThat(backstagePass.getQuality(), is(21));
    }

    @Test
    public void shouldIncreaseQualityByTwoWhenSixToTenDaysToSellin()
    {
        Item backstagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 20);

        GildedRose.updateQuality(Arrays.asList(backstagePass));

        assertThat(backstagePass.getQuality(), is(22));

        backstagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 6, 20);

        GildedRose.updateQuality(Arrays.asList(backstagePass));

        assertThat(backstagePass.getQuality(), is(22));
    }

    @Test
    public void shouldIncreaseQualityByThreeWhenOneToFiveDaysToSellin()
    {
        Item backstagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 20);

        GildedRose.updateQuality(Arrays.asList(backstagePass));

        assertThat(backstagePass.getQuality(), is(23));

        backstagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 1, 20);

        GildedRose.updateQuality(Arrays.asList(backstagePass));

        assertThat(backstagePass.getQuality(), is(23));
    }

    @Test
    public void shouldHaveZeroQualityWhenSoldDateExpired()
    {
        Item backstagePass = new Item("Backstage passes to a TAFKAL80ETC concert", 0, 20);

        GildedRose.updateQuality(Arrays.asList(backstagePass));

        assertThat(backstagePass.getQuality(), is(0));
    }
}
