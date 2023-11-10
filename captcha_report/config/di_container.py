from kink import di
from captcha_report.config.settings import Settings
from captcha_report.database.connection.alchemy_connection import SqlAlchemyConnection


def setup_di_container() -> None:
    di["settings"] = Settings()
    di[SqlAlchemyConnection] = lambda di: SqlAlchemyConnection(
        database_url=di["settings"].database_url,
        echo=di["settings"].echo,
    )
