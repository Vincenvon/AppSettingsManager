import React from 'react';
import { Route, Switch } from 'react-router-dom';
import WhiteTextTypography from 'root/components/Typography';
import { History, Login, Settings } from 'root/pages';
import Menu from '../layout/Menu';
import * as S from './styled';

const Layout = () => {
    return (
        <S.Main>
            <Switch>
                <Route path="/login" component={Login} exact />
                <Route path="*" render={() => {
                    return <>
                        <S.MenuContainer>
                            <Menu />
                        </S.MenuContainer>
                        <S.BodyContainer>
                            <S.HeaderContainer>
                                <WhiteTextTypography component="h1" variant="h6" css noWrap> Application Manager</WhiteTextTypography>
                            </S.HeaderContainer>
                            <S.ContentContainer>
                                <Switch>
                                    <Route path="/history" component={History} exact />
                                    <Route path="/" component={Settings} exact />
                                    <Route path="*" render={() => <p>Not Found</p>} />
                                </Switch>
                            </S.ContentContainer>
                        </S.BodyContainer>
                    </>
                }} exact />
            </Switch>
        </S.Main>
    );
}

export default Layout;