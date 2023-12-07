import React from "react";
import classes from "./filter.module.css";
import { Box, Flex, NumberInput, SimpleGrid, Text, rem } from "@mantine/core";
import { IconX, IconCurrencyDram  } from "@tabler/icons-react";

const Filter = () => {
    const icon = <IconCurrencyDram style={{ width: rem(0), height: rem(0) }} stroke={0} />;
    const from = <Text size="14px">From:</Text>;
	return (
		<Box className={classes.filterbox}>
			<SimpleGrid cols={2} spacing={0} className={classes.container}>
				<Text fw="bold" size="20px" className={classes.filtermain}>
					Filters
				</Text>
				<Flex align="center" className={classes.resetButton} gap={5}>
					<Text size="14px">
						Reset
					</Text>
					<IconX size={14}/>
				</Flex>

				<Box className={classes.filterContentBox2}>
					<Text fw="bold" size="16px">Price</Text>
				</Box>
				<NumberInput styles={{section: {marginLeft: '10px'}, input: {paddingLeft: '50px'}}} prefix="$" className={classes.moneyFilter} leftSection={from} rightSection={icon}/>
				<NumberInput styles={{section: {marginLeft: '10px'}, input: {paddingLeft: '50px'}}} prefix="$" className={classes.moneyFilter} leftSection={from} rightSection={icon}/>
			</SimpleGrid>
		</Box>
	);
};

export default Filter;
