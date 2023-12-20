import { Box, Image, SimpleGrid } from "@mantine/core";
import React, { PropsWithChildren } from 'react';
import classes from "./layout.module.css";

const AuthLayout = ({ children }: PropsWithChildren) => {
  return (
    // <Box className={classes.testcontainer}>
    //   <div>1</div>
    // </Box>

    <SimpleGrid cols={{ lg: 2, sm: 1 }} className={classes.testcontainer}>
      {children}
      <Box p="1rem" className={classes.image} h="100vh">
        <Image src="https://res.cloudinary.com/dyregmisw/image/upload/v1703103668/uu2qqmcyjq2z7nbsyza3.png" h="100%" />
      </Box>
    </SimpleGrid>
  );
};

export default AuthLayout;